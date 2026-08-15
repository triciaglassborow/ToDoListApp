using Microsoft.EntityFrameworkCore;

public class ToDoListAppContext(DbContextOptions<ToDoListAppContext> options) : DbContext(options)
{
    public DbSet<ToDoListApp.Models.ToDoTask> ToDoTask { get; set; } = default!;
}
