using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        public TodosController()
        {
                
        }

        [HttpGet]
        public IActionResult GetTodos() { return Ok(); }
    }
}
