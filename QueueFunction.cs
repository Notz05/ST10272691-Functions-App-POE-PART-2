using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using QueueTriggerAttribute = Microsoft.Azure.Functions.Worker.QueueTriggerAttribute;

namespace ST10272691_Functions_App
{
    public class QueueFunction
    {
        private readonly ILogger _logger;

        public QueueFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<QueueFunction>();
        }

        [Function("ProcessQueueMessage")]
        public void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")] string myQueueItem)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
