
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
        // var todoTask = GraphModel.GetRandomTodoTask("My Task", dateTimes);
        // var result = await operations.AddTodoTaskAsync(todoTask);
        // Console.WriteLine($"Task {result.Title} created at {result.CreatedDateTime}");
        var noteBook = GraphModel.GetRandomNotebook("My Notebook", user, dateTimes);
        var result = await operations.AddOneNoteAsync(noteBook);
        Console.WriteLine($"Notebook {result.DisplayName} created at {result.CreatedDateTime}");
    }
    catch (ODataError error)
    {
        Console.WriteLine($"Code-{error.Error.Code}, Message-{error.Error.Message}, Details-{error.Error.Details}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}