using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.DataAccess;
using TaskAPI.Models;

namespace TaskAPI.Services.Todos
{
    public class ToDoSqlServerService : ITodoReporsitory
    {
        private readonly ToDoDbContext _context = new ToDoDbContext();
        public List<Todo> AllToDos(int authorId)
        {
            return _context.Todos.Where(t => t.AuthorId == authorId).ToList();
        }

        public Todo GetToDo(int id)
        {
            return _context.Todos.Find(id);
        }

        public Todo AddTodo (int authorId, Todo todo ) 
        {
            todo.AuthorId = authorId;

            _context.Todos.Add(todo);
            _context.SaveChanges();

            return _context.Todos.Find(todo.Id);
        }
    }
}
