using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

    public async Task OnGetAsync()
    {
        ToDoTask = await _context.ToDoTask.ToListAsync();
    }
}
