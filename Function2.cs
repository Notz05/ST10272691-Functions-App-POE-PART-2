using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ST10272691_Functions_App
{
    public class Function2
    {
        private readonly ILogger<Function2> _logger;

        public Function2(ILogger<Function2> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Function2))]
        public void Run([QueueTrigger("myqueue-items", Connection = "DefaultEndpointsProtocol=https;AccountName=st10272691storage;AccountKey=r/j6vSozQ1ffM+pkg9llTNN34Wzp1UhTuU90S3umsIqWqqS5X1OiPD3sTZ0hSkSp6eGNrW/Wq0uM+AStvMr2Xw==;EndpointSuffix=core.windows.net")] QueueMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.MessageText}");
        }
    }
}
