namespace HackGraph.Services;

public class Operations : IOperations
{
    private readonly GraphServiceClient graphServiceClient;

    public Operations(GraphServiceClient graphServiceClient)
        => this.graphServiceClient = graphServiceClient;

    public async ValueTask<User> GetUserAsync()
        => await graphServiceClient.Me.GetAsync();

    public async ValueTask<Notebook> AddOneNoteAsync(Notebook notebook)
        => await graphServiceClient.Me.Onenote.Notebooks.PostAsync(notebook);

    public async ValueTask<TodoTask> AddTodoTaskAsync(TodoTask todoTask)
        => await graphServiceClient.Me.Todo.Lists["Tasks"].Tasks.PostAsync(todoTask);

    public async ValueTask<NotebookCollectionResponse> GetAllOneNotesAsync()
        => await graphServiceClient.Me.Onenote.Notebooks.GetAsync();
}