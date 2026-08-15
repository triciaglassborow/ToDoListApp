using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ToDoTasks;

public class DetailsModel : PageModel
{
    private readonly ToDoListAppContext _context;
    public DetailsModel(ToDoListAppContext context)
    {
        _context = context;
    }

    public ToDoTask ToDoTask { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? taskid)
    {
        if (taskid is null)
        {
            return NotFound();
        }

        var todotask = await _context.ToDoTask.FirstOrDefaultAsync(m => m.TaskID == taskid);
        if (todotask is null)
        {
            return NotFound();
        }
        else
        {
            ToDoTask = todotask;
        }

        return Page();
    }
}
