using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ToDoLists;

public class IndexModel : PageModel
{
    private readonly ToDoListAppContext _context;

    public IndexModel(ToDoListAppContext context)
    {
        _context = context;
    }

    public IList<ToDoList> ToDoList { get; set; } = default!;

    public async Task OnGetAsync()
    {
        ToDoList = await _context.ToDoList.ToListAsync();
    }
}
