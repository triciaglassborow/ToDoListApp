using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class ToDoList
    {
        [Key]
        public int ListID { get; set; }

        [Required]
        public string ListName { get; set; }

        public ICollection<ToDoTask> ToDoTasks { get; set; } = new List<ToDoTask>();
    }
}
