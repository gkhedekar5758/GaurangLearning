using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.Data;
using WebApiToDo.Model;

namespace WebApiToDo.Service
{
    public class ToDoService : IToDoService
    {
        PracticeDBContext _database = null;
        public ToDoService(PracticeDBContext practiceDBContext, IWebHostEnvironment webHostEnvironment)
        {
            _database = practiceDBContext;
        }



        public void AddToDO(ToDoItem toDoItem)
        {
            _database.addTodoInDB(toDoItem);
        }

        public string DeleteTodo(int id)
        {
            string rt = _database.DeleteTodoDB(id);
            return rt;
        }

        public IEnumerable<ToDoItem> GetToDoByStatus(int name)
        {
            return _database.getToDOByStatus(name);
        }

        public IEnumerable<ToDoItem> GetToDoByUser(int Userid)
        {
            return _database.getToDOByUser(Userid);
        }

        public IEnumerable<ToDoItem> GetToDos()
        {
            return _database.getTodoFromDB();
        }

        public string UpdateToDo(int id, ToDoItem toDoItem)
        {
            string retStr = _database.updateTodo(id, toDoItem);
            return retStr;
        }
    }
}
