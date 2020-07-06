using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.Model;

namespace WebApiToDo.Service
{
    public interface IToDoService
    {
        public IEnumerable<ToDoItem> GetToDos();
        public IEnumerable<ToDoItem> GetToDoByUser(int Userid);
        public IEnumerable<ToDoItem> GetToDoByStatus(int name);
        public void AddToDO(ToDoItem toDoItem);
        public string UpdateToDo(int id, ToDoItem toDoItem);
        public string DeleteTodo(int id);
    }
}
