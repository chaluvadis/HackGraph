namespace HackGraph.Services;
public interface IOperations
{
    ValueTask<User> GetUserAsync();
}