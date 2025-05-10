using Microsoft.AspNetCore.Mvc;
using Project.Models;
using System.Linq;
using Task = Project.Models.Task;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private static List<Task> tasks = new List<Task>();

    // GET: api/tasks
    [HttpGet]
    public ActionResult<IEnumerable<Task>> GetTasks()
    {
        return Ok(tasks);
    }

    // POST: api/tasks
    [HttpPost]
    public ActionResult<Task> CreateTask([FromBody] Task task)
    {
        task.Id = tasks.Count + 1;  // Simple ID generation logic
        tasks.Add(task);
        return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
    }

    // PUT: api/tasks/{id}
    [HttpPut("{id}/undo")]
    public IActionResult UndoTask(int id)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return NotFound();

        task.Undo();
        return NoContent();
    }

    [HttpPut("{id}/state")]
    public IActionResult ChangeTaskState(int id, [FromBody] string newState)
    {
        var task = tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return NotFound();

        task.Next();
        return NoContent();
    }
}
