using Microsoft.EntityFrameworkCore;
using ToDoListApp.Models;

public class ToDoListAppContext(DbContextOptions<ToDoListAppContext> options) : DbContext(options)
{
    public DbSet<ToDoListApp.Models.ToDoTask> ToDoTask { get; set; }
    public DbSet<ToDoList> ToDoList { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ToDoTask>()
            .HasOne(t => t.ToDoList)
            .WithMany(l => l.ToDoTasks)
            .HasForeignKey(t => t.ListID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}


