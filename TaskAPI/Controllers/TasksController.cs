using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        [HttpGet]
        public IActionResult Tasks()
        {
            var tasks = new string[] { "Task1", "Task2" };
            return Ok(tasks);
        }

        [HttpPost]
        public IActionResult AddTasks() { return Ok(); }

        [HttpPut]
        public IActionResult UpdateTasks() { return Ok();}

        [HttpDelete]
        public IActionResult DeleteTasks() { return Ok();}
    }
}
