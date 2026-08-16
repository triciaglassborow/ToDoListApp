using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ToDoLists;

public class EditModel : PageModel
{
    private readonly ToDoListAppContext _context;

    public EditModel(ToDoListAppContext context)
    {
        _context = context;
    }

    [BindProperty]
    public ToDoList ToDoList { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? listid)
    {
        if (listid is null)
        {
            return NotFound();
        }

        var todolist = await _context.ToDoList.FirstOrDefaultAsync(m => m.ListID == listid);
        if (todolist is null)
        {
            return NotFound();
        }
        ToDoList = todolist;
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

        _context.Attach(ToDoList).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ToDoListExists(ToDoList.ListID))
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

    private bool ToDoListExists(int listid)
    {
        return _context.ToDoList.Any(e => e.ListID == listid);
    }
}
