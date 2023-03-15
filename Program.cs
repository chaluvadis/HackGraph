


var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((_, config) => config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true))
    .ConfigureServices((context, services) => services.ConfigureGraphClient(context.Configuration))
    .ConfigureServices((_, services) =>
    {
        services.AddScoped<IOperations, Operations>();
        services.AddScoped<IDateTimes, DateTimes>();
    })
    .ConfigureLogging((context, logging) => logging.AddConfiguration(context.Configuration.GetSection("Logging")))
    .Build();

var operations = host.Services.GetRequiredService<IOperations>();

var dateTimes = host.Services.GetRequiredService<IDateTimes>();

var user = await operations.GetUserAsync();

if (user is not null)
{
    try
    {
        Console.WriteLine($"User {user.DisplayName} found");
        var result = await operations.GetAllOneNotesAsync();
        Console.WriteLine($"Notebooks {JsonSerializer.Serialize(result)}");
        Console.WriteLine($"Notebook {result.OdataCount} created at {result.Value[0].CreatedDateTime}");
    }
    catch (ApiException error)
    {
        GraphModel.PrintApiException(error);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}