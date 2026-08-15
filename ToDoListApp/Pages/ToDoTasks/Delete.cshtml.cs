using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ToDoTasks;

public class DeleteModel : PageModel
{
    private readonly ToDoListAppContext _context;

    public DeleteModel(ToDoListAppContext context)
    {
        _context = context;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? taskid)
    {
        if (taskid is null)
        {
            return NotFound();
        }

        var todotask = await _context.ToDoTask.FindAsync(taskid);
        if (todotask != null)
        {
            ToDoTask = todotask;
            _context.ToDoTask.Remove(ToDoTask);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
