
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
    Console.WriteLine($"User {user.DisplayName} found");
    var noteBook = GetRandomNotebook("My Notebook", user);
    var result = await operations.AddOneNoteAsync(noteBook);
    Console.WriteLine($"Notebook {result.DisplayName} created at {result.CreatedDateTime}");
}

Notebook GetRandomNotebook(string name, User user)
{
    var notebook = new Notebook
    {
        Id = Guid.NewGuid().ToString(),
        DisplayName = name,
        IsDefault = true,
        UserRole = OnenoteUserRole.Owner,
        CreatedBy = new IdentitySet
        {
            User = new Identity
            {
                DisplayName = user.DisplayName,
                Id = user.Id,
                AdditionalData = new Dictionary<string, object>
                {
                    { "userPrincipalName", user.UserPrincipalName },
                },
                OdataType = "#microsoft.graph.user",
            },
        },
        CreatedDateTime = dateTimes.GetCurrentDateTime(),
        OdataType = "#microsoft.graph.notebook",
    };
    return notebook;
}