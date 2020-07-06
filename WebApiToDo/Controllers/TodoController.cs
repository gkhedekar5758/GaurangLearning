using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiToDo.Data;
using WebApiToDo.Model;
using WebApiToDo.Service;

namespace WebApiToDo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        
        IToDoService _toDoService = null;
        PracticeDBContext _practiceDBContext = null;
        public TodoController(IToDoService toDoService,PracticeDBContext practiceDBContext)
        {
            _practiceDBContext = practiceDBContext;
            _toDoService = toDoService;
        }
        // GET: api/Todo
        [HttpGet]
        public IEnumerable<ToDoItem> Get()
        {
            IEnumerable<ToDoItem> toDoItems = _toDoService.GetToDos();
            return toDoItems;
        }

        // GET: api/Todo/5
        [HttpGet]
        [Route("byuser/{userid}")]
        public IEnumerable<ToDoItem> Get(int userid)
        {
            return _toDoService.GetToDoByUser(userid);
        }

        [HttpGet]
        [Route("bystatus/{status}")]
        public IEnumerable<ToDoItem> getByStatus(int status)
        {
            return _toDoService.GetToDoByStatus(status);
        }

        // POST: api/Todo
        [HttpPost]
        public void Post([FromBody] ToDoItem value)
        {
            _toDoService.AddToDO(value);
        }

        // PUT: api/Todo/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] ToDoItem value)
        {
            string result ;
            result = _toDoService.UpdateToDo(id, value);

            if (result.Equals("Done")) return StatusCodes.Status200OK;
            else if (result.Contains("found")) return StatusCodes.Status204NoContent;
            return 0;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string result = _toDoService.DeleteTodo(id);
            return result;
        }
    }
}
