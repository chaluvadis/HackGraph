namespace HackGraph.Brokers.DateTimes;
public class DateTimes : IDateTimes
{
    public DateTimeOffset GetCurrentDateTime() => DateTimeOffset.Now;
    public DateTimeTimeZone GetCurrentDateTimeTimeZone() => new DateTimeTimeZone
    {
        DateTime = GetCurrentDateTime().ToString("o"),
        TimeZone = "UTC"
    };
}