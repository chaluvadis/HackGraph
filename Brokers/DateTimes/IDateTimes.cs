namespace HackGraph.Brokers.DateTimes;
public interface IDateTimes
{
    DateTimeOffset GetCurrentDateTime();
    DateTimeTimeZone GetCurrentDateTimeTimeZone();
}