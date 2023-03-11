namespace HackGraph.Extensions;
public static class DateTimeExtensions
{
    public static DateTimeTimeZone AddDays(this DateTimeTimeZone dateTimeTimeZone, int days)
    {
        var dateTime = DateTimeOffset.Parse(dateTimeTimeZone.DateTime);
        var newDateTime = dateTime.AddDays(days);
        return new DateTimeTimeZone
        {
            DateTime = newDateTime.ToString("o"),
            TimeZone = dateTimeTimeZone.TimeZone
        };
    }

    public static DateTimeTimeZone AddHours(this DateTimeTimeZone dateTimeTimeZone, int hours)
    {
        var dateTime = DateTimeOffset.Parse(dateTimeTimeZone.DateTime);
        var newDateTime = dateTime.AddHours(hours);
        return new DateTimeTimeZone
        {
            DateTime = newDateTime.ToString("o"),
            TimeZone = dateTimeTimeZone.TimeZone
        };
    }
}