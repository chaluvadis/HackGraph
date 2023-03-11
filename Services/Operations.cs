namespace HackGraph.Services;

public class Operations : IOperations
{
    private readonly GraphServiceClient graphServiceClient;

    public Operations(GraphServiceClient graphServiceClient)
        => this.graphServiceClient = graphServiceClient;

    public async ValueTask<User> GetUserAsync()
    {
        return await graphServiceClient.Me.GetAsync();
    }
}