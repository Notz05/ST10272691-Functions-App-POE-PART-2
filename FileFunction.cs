using Azure;
using Azure.Storage.Files.Shares;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;


namespace ST10272691_Functions_App
{
    public class FileFunction
    {
        private readonly ILogger _logger;

        public FileFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FileFunction>();
        }

        [Function("UploadFile")]
        public async Task UploadFile([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function for file upload.");

            string connectionString = "DefaultEndpointsProtocol=https;AccountName=st10272691storage;AccountKey=r/j6vSozQ1ffM+pkg9llTNN34Wzp1UhTuU90S3umsIqWqqS5X1OiPD3sTZ0hSkSp6eGNrW/Wq0uM+AStvMr2Xw==;EndpointSuffix=core.windows.net";
            ShareClient shareClient = new ShareClient(connectionString, "your-file-share");
            ShareDirectoryClient directoryClient = shareClient.GetRootDirectoryClient();

            ShareFileClient fileClient = directoryClient.GetFileClient("your-file.txt");

            using (var stream = new MemoryStream())
            {
                await req.Body.CopyToAsync(stream);
                stream.Position = 0;
                await fileClient.CreateAsync(stream.Length);
                await fileClient.UploadRangeAsync(new HttpRange(0, stream.Length), stream);
            }
        }
    }
}
