using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.DataAccess;
using TaskAPI.Models;

namespace TaskAPI.Services.Todos
{
    public class ToDoSqlServerService : ITodoReporsitory
    {
        private readonly ToDoDbContext _context = new ToDoDbContext();
        public List<Todo> AllToDos()
        {
            return _context.Todos.ToList();
        }
    }
}
