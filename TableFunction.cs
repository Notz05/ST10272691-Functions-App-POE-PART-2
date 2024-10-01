using Azure.Data.Tables;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using TimerInfo = Microsoft.Azure.Functions.Worker.TimerInfo;
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

            string connectionString = "YourConnectionString"; // Best to store securely
            TableClient tableClient = new TableClient(connectionString, "YourTableName");

            // Add entity to the table
            var entity = new TableEntity("PartitionKey", "RowKey")
            {
                { "FirstName", "Kiirreenn" },
                { "LastName", "Guunndduu" }
            };

            tableClient.AddEntity(entity);
            _logger.LogInformation("Entity added to Table Storage.");
        }
    }
}
