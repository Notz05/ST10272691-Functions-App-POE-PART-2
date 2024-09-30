using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using TimerInfo = Microsoft.Azure.WebJobs.TimerInfo;
using TimerTriggerAttribute = Microsoft.Azure.Functions.Worker.TimerTriggerAttribute;

namespace ST10272691_Functions_App
{
    public class TableFunction
    {
        private readonly ILogger _logger;

        public TableFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<TableFunction>();
        }

        [Function("InsertTableEntity")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            string connectionString = "DefaultEndpointsProtocol=https;AccountName=st10272691storage;AccountKey=r/j6vSozQ1ffM+pkg9llTNN34Wzp1UhTuU90S3umsIqWqqS5X1OiPD3sTZ0hSkSp6eGNrW/Wq0uM+AStvMr2Xw==;EndpointSuffix=core.windows.net";
            TableClient tableClient = new TableClient(connectionString, "YourTableName");

            // Add entity to the table
            var entity = new TableEntity("PartitionKey", "RowKey")
            {
                { "FirstName", "John" },
                { "LastName", "Doe" }
            };

            tableClient.AddEntity(entity);
            _logger.LogInformation("Entity added to Table Storage.");
        }

    }
}
