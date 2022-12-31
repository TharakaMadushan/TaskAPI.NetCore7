using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskAPI.Models;
using TaskAPI.Services.Models;
using TaskAPI.Services.Todos;

namespace TaskAPI.Controllers
{
    [Route("api/authors/{authorId}/todos")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private ITodoReporsitory _toDoService;
        private IMapper _mapper;

        public TodosController(ITodoReporsitory _repo, IMapper mapper)
        {
            _toDoService = _repo;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ICollection<TodoDTO>> GetTodos(int authorId) 
        {
            //throw new Exception("Test error");
            var myTodos = _toDoService.AllToDos(authorId);
            var mappedTodos = _mapper.Map<ICollection<TodoDTO>>(myTodos);
            return Ok(mappedTodos); 
        }

        [HttpGet("{id}", Name ="GetTodo")]
        public IActionResult GetToDo(int authorId,int id)
        {
            var todo = _toDoService.GetToDo(authorId,id);
            if (todo is null)
            {
                return NotFound();
            }
            var mappedTodo = _mapper.Map<TodoDTO>(todo);
            return Ok(mappedTodo);
        }

        [HttpPost]
        public ActionResult<TodoDTO> CreateToDo(int authorId, CreateToDoDTO todo) 
        {
            var todoEntity = _mapper.Map<Todo>(todo);
            var newTodo = _toDoService.AddTodo(authorId, todoEntity);

            var todoForReturn = _mapper.Map<TodoDTO>(newTodo);
            return CreatedAtRoute("GetTodo", new {authorid = authorId, id = todoForReturn.Id}, todoForReturn);  
        }

        [HttpPut("{todoId}")]
        public ActionResult UpdateToDo (int todoId, int authorId, UpdateTodoDTO todo)
        {
            var updatingTodo = _toDoService.GetToDo(todoId, authorId);

            if (updatingTodo is null)
            {
                return NotFound();
            }

            _mapper.Map(todo, updatingTodo);
            _toDoService.UpdateTodo(updatingTodo);

            return NoContent();
        }

        [HttpDelete("{todoId}")]
        public ActionResult DeleteToDo (int todoId, int authorId)
        {
            var deleteTodo = _toDoService.GetToDo(todoId, authorId);

            if (deleteTodo is null)
            {
                return NotFound();
            }

            _toDoService.DeleteTodo(deleteTodo);
            return NoContent();
        }
    }
}
