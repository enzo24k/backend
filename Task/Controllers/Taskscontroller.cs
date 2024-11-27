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
        public ActionResult<List<Modeltask>>

            addTask(Modeltask newTask) {


        
            if (newTask.Description.Length < 10)
                    
            
            return BadRequest("A tarefa não pode ser nula.");
            

           newTask.Id = modelTasks.Count > 0 ? modelTasks[modelTasks.Count - 1].Id + 1 : 1;
            

            modelTasks.Add(newTask);

            return Ok(modelTasks);
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
