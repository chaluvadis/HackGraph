using HackGraph.Services;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((_, config) => config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true))
    .ConfigureServices((context, services) => services.ConfigureGraphClient(context.Configuration))
    .ConfigureServices((_, services) => services.AddScoped<IOperations, Operations>())
    .ConfigureLogging((context, logging) => logging.AddConfiguration(context.Configuration.GetSection("Logging")))
    .Build();

var operations = host.Services.GetRequiredService<IOperations>();
var user = await operations.GetUserAsync();
Console.WriteLine($"Hello {user?.DisplayName}!");