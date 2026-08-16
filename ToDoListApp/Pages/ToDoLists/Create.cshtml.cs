using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ToDoLists;

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
    public ToDoList ToDoList { get; set; } = default!;

    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.ToDoList.Add(ToDoList);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
