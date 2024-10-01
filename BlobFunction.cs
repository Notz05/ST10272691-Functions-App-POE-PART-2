using Azure.Storage.Blobs;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ST10272691_Functions_App
{
    public class BlobFunction
    {
        private readonly ILogger _logger;

        public BlobFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BlobFunction>();
        }

        [Function("UploadBlob")]
        public async Task UploadBlob([BlobTrigger("samples-workitems/{name}")] Stream myBlob, string name)
        {
            _logger.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            string connectionString = "YourConnectionString"; // Best to store securely
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("your-container");

            BlobClient blobClient = containerClient.GetBlobClient(name);
            await blobClient.UploadAsync(myBlob, true);
        }
    }
}
