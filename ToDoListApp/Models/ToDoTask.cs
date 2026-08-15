using System.ComponentModel.DataAnnotations;

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
    }
}
