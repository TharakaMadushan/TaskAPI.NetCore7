using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Services;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private ITodoReporsitory _toDoService;

        public TodosController(ITodoReporsitory _repo)
        {
            _toDoService = _repo;
        }

        [HttpGet("{id?}")]
        public IActionResult GetTodos(int? id) 
        {
            var myTodos = _toDoService.AllToDos();
            if (id == null) return Ok(myTodos);
            myTodos = myTodos.Where(t => t.Id == id)
                .ToList();
            return Ok(myTodos); 
        }
    }
}
