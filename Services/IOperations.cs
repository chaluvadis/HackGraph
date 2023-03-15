namespace HackGraph.Services;
public interface IOperations
{
    ValueTask<User> GetUserAsync();
    ValueTask<Notebook> AddOneNoteAsync(Notebook notebook);
    ValueTask<TodoTask> AddTodoTaskAsync(TodoTask todoTask);
    ValueTask<NotebookCollectionResponse> GetAllOneNotesAsync();
}