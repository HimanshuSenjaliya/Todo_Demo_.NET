using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using Microsoft.AspNetCore.Http;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private static List<TodoItem> _items = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "Learn ASP.NET Core", IsCompleted = false },
            new TodoItem { Id = 2, Title = "Complete Coursera Assignment", IsCompleted = true }
        };

        [HttpGet]
        public ActionResult<IEnumerable<TodoItem>> Get() => Ok(_items);

        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public ActionResult<TodoItem> Post([FromBody] TodoItem item)
        {
            item.Id = _items.Max(i => i.Id) + 1;
            _items.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TodoItem updatedItem)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            item.Title = updatedItem.Title;
            item.IsCompleted = updatedItem.IsCompleted;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _items.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            _items.Remove(item);
            return NoContent();
        }
    }
}
