using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;


namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private static List<Modeltask> modelTasks = new List<Modeltask>();

        [HttpGet]
        public ActionResult<List<Modeltask>> SearchTasks()
        {
            return Ok(modelTasks);
        }

        [HttpPost]
        public ActionResult<Modeltask> AddTask([FromBody] Modeltask newTask)
        {
            if (newTask == null)
            {
                return BadRequest("A tarefa não pode ser nula.");
            }

            if (string.IsNullOrEmpty(newTask.Description) || newTask.Description.Length < 10)
            {
                return BadRequest("A descrição da tarefa deve ter no mínimo 10 caracteres.");
            }

            modelTasks.Add(newTask);

            return CreatedAtAction(nameof(SearchTasks), new { id = newTask.Id }, newTask);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteTask(int id)
        {
            var taskToDelete = modelTasks.FirstOrDefault(t => t.Id == id);

            if (taskToDelete == null)
            {
                return NotFound($"Tarefa com ID {id} não encontrada.");
            }

            modelTasks.Remove(taskToDelete);

            return NoContent();
        }
    }
}
