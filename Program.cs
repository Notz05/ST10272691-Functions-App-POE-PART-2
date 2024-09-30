using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureLogging(logging =>
    {
        logging.AddConsole(); // Add console logging
        logging.AddDebug();   // Add debug logging
    })
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        // Register additional services here
        // services.AddScoped<IMyService, MyService>();
    })
    .Build();

try
{
    host.Run();
}
catch (Exception ex)
{
    // Log the exception or handle it appropriately
    Console.WriteLine($"An error occurred while starting the host: {ex.Message}");
}
