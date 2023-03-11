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

    public static Notebook GetRandomNotebook(string name, User user, IDateTimes dateTimes)
    {
        return new Notebook
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
    }
}