using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ToDoTasks;

public class IndexModel : PageModel
{
    private readonly ToDoListAppContext _context;

    public IndexModel(ToDoListAppContext context)
    {
        _context = context;
    }

    public IList<ToDoTask> ToDoTask { get; set; } = default!;

    public async Task OnGetAsync(int? listId)
    {
        if (listId.HasValue) //tasks in a list
        {
            ToDoTask = await _context.ToDoTask
                .Where(t => t.ListID == listId.Value)
                .Include(t => t.ToDoList)
                .ToListAsync();
        }
        else //all tasks
        {
            ToDoTask = await _context.ToDoTask
                .Include(t => t.ToDoList)
                .ToListAsync();
        }
    }
}
