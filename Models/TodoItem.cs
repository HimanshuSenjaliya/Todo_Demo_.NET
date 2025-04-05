using System.Collections.Generic;
using System.Linq;
namespace ToDoApi.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public bool IsCompleted { get; set; }
    }
}
