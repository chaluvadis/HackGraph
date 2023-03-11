namespace HackGraph.Brokers.DateTimes;
public class DateTimes : IDateTimes
{
    public DateTimeOffset GetCurrentDateTime() => DateTimeOffset.Now;
}