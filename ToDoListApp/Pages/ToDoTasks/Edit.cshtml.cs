using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ToDoTasks;

public class EditModel : PageModel
{
    private readonly ToDoListAppContext _context;

    public EditModel(ToDoListAppContext context)
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
        ToDoTask = todotask;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(ToDoTask).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ToDoTaskExists(ToDoTask.TaskID))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool ToDoTaskExists(int taskid)
    {
        return _context.ToDoTask.Any(e => e.TaskID == taskid);
    }
}
