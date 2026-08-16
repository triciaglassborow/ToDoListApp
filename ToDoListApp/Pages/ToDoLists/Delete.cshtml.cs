using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ToDoLists;

public class DeleteModel : PageModel
{
    private readonly ToDoListAppContext _context;

    public DeleteModel(ToDoListAppContext context)
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
        else
        {
            ToDoList = todolist;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int? listid)
    {
        if (listid is null)
        {
            return NotFound();
        }

        var todolist = await _context.ToDoList.FindAsync(listid);
        if (todolist != null)
        {
            ToDoList = todolist;
            _context.ToDoList.Remove(ToDoList);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("./Index");
    }
}
