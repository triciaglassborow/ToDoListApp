using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoListApp.Models
{
    public class ToDoTask
    {
        [Key]
        public int TaskID { get; set; }
        public int ListID { get; set; }
        public string TaskName { get; set; }
        public string? Details { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }
        public string? Priority { get; set; }
        public bool IsComplete { get; set; }
        public ToDoList ToDoList { get; set; }
    }

    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ToDoListAppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ToDoListAppContext>>()))
            {
                if (context == null || context.ToDoTask == null)
               {
                    throw new ArgumentNullException("Null ToDoListAppContext");
                }

                // Look for any tasks.
                if (context.ToDoTask.Any())
                {
                    return;   // DB has been seeded
                }

                context.ToDoTask.AddRange(
                    new ToDoTask
                    {
                        ListID = 1,
                        TaskName = "Buy groceries",
                        Details = "Milk, bread, eggs",
                        DueDate = DateTime.Parse("2026-08-17"),
                        Priority = "High",
                        IsComplete = false
                    },
                    new ToDoTask
                    {
                        ListID = 1,
                        TaskName = "Walk the dog",
                        Details = "quick 30 minute walk",
                        DueDate = DateTime.Parse("2026-08-15"),
                        Priority = "Medium",
                        IsComplete = false
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
