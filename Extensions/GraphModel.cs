namespace HackGraph.Extensions;
public static class GraphModel
{
    public static TodoTask GetRandomTodoTask(string taskTitle, IDateTimes dateTimes)
    {
        return new TodoTask
        {
            Id = Guid.NewGuid().ToString(),
            Title = taskTitle,
            CreatedDateTime = dateTimes.GetCurrentDateTime(),
            StartDateTime = dateTimes.GetCurrentDateTimeTimeZone(),
            DueDateTime = dateTimes.GetCurrentDateTimeTimeZone().AddDays(1),
            IsReminderOn = true,
            ReminderDateTime = dateTimes.GetCurrentDateTimeTimeZone().AddHours(1),
            Status = Microsoft.Graph.Models.TaskStatus.NotStarted,
            Importance = Importance.High,
            OdataType = "#microsoft.graph.todoTask"
        };
    }

    public static Notebook GetRandomNotebook(string name) => new()
    {
        DisplayName = name,
    };

    public static void PrintApiException(ApiException error)
    {
        Console.WriteLine($"Data-{JsonSerializer.Serialize(error.Data)}"
       + $"{Environment.NewLine}Message-{error.Message}"
       + $"{Environment.NewLine}StackTrace-{error.StackTrace}"
       + $"{Environment.NewLine}InnerException-{error.InnerException}"
       + $"{Environment.NewLine}HelpLink-{error.HelpLink}"
       + $"{Environment.NewLine}Source-{error.Source}"
       + $"{Environment.NewLine}TargetSite-{error.TargetSite}"
       + $"{Environment.NewLine}ApiResponse-{error.ResponseStatusCode}");
    }
}