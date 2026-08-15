using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ToDoTasks;

public class CreateModel : PageModel
{
    private readonly ToDoListAppContext _context;

    public CreateModel(ToDoListAppContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public ToDoTask ToDoTask { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.ToDoTask.Add(ToDoTask);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
