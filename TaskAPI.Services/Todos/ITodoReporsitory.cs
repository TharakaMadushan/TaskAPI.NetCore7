using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskAPI.Models;

namespace TaskAPI.Services.Todos
{
    public interface ITodoReporsitory
    {
        public List<Todo> AllToDos(int authorId);
        public Todo GetToDo(int id, int authorId);
        public Todo AddTodo(int authorId, Todo todo);
        public void UpdateTodo(Todo todo);
        public void DeleteTodo(Todo todo);
    }
}
