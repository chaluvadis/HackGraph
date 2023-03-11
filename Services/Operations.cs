namespace HackGraph.Services;

public class Operations : IOperations
{
    private readonly GraphServiceClient graphServiceClient;

    public Operations(GraphServiceClient graphServiceClient)
        => this.graphServiceClient = graphServiceClient;

    public async ValueTask<User> GetUserAsync()
        => await graphServiceClient.Me.GetAsync();

    public async ValueTask<Notebook> AddOneNoteAsync(Notebook notebook)
    {
        try
        {
            return await graphServiceClient.Me.Onenote.Notebooks.PostAsync(notebook);
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw;
        }
    }
}