using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ST10272691_Functions_App
{
    public class Function
    {
        private readonly ILogger<Function> _logger;

        public Function(ILogger<Function> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Function))]
        public async Task Run([BlobTrigger("samples-workitems/{name}", Connection = "DefaultEndpointsProtocol=https;AccountName=st10272691storage;AccountKey=r/j6vSozQ1ffM+pkg9llTNN34Wzp1UhTuU90S3umsIqWqqS5X1OiPD3sTZ0hSkSp6eGNrW/Wq0uM+AStvMr2Xw==;EndpointSuffix=core.windows.net")] Stream stream, string name)
        {
            using var blobStreamReader = new StreamReader(stream);
            var content = await blobStreamReader.ReadToEndAsync();
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name: {name} \n Data: {content}");
        }
    }
}
