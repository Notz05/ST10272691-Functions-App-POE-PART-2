using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ST10272691_Functions_App
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [Function("Function1")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation($"Received a {req.Method} request at {req.Url}");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            try
            {
                if (req.Method == HttpMethods.Post)
                {
                    var requestBody = await req.ReadAsStringAsync();
                    _logger.LogInformation($"Received POST request with body: {requestBody}");

                    if (string.IsNullOrWhiteSpace(requestBody))
                    {
                        response.StatusCode = HttpStatusCode.BadRequest;
                        response.WriteString("Request body cannot be empty.");
                        return response;
                    }

                    response.WriteString($"Received your data: {requestBody}");
                }
                else
                {
                    response.WriteString("Welcome to Azure Functions!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing the request.");
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.WriteString("An internal error occurred.");
            }

            return response;
        }
    }
}
