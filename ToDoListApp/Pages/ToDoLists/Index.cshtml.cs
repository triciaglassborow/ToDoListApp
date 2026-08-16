using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

namespace ToDoListApp.Pages.ToDoLists;


public class IndexModel : PageModel
{
    public IList<ToDoTask> ToDoTask { get; set; } = default!;

    public int? ListID { get; set; }

    private readonly ToDoListAppContext _context;

    public IndexModel(ToDoListAppContext context)
    {
        _context = context;
    }

    public IList<ToDoList> ToDoList { get; set; } = default!;

    public async Task OnGetAsync(int? listId)
    {
        ListID = listId;

        var query = _context.ToDoTask.AsQueryable();

        if (listId.HasValue)
        {
            query = query.Where(t => t.ListID == listId.Value);
        }

        ToDoTask = await query.ToListAsync();
    }
}
