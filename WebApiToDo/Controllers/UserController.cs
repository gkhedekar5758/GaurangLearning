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
    public class UserController : ControllerBase
    {
        readonly PracticeDBContext practiceDBContext = null;
        private IUserService _User = null;
        public UserController(PracticeDBContext context, IUserService userService)
        {
            _User = userService;
            practiceDBContext = context;
        }

        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            IEnumerable<User> products = null;
            products = _User.GetUsers();

            return products;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            return _User.GetUserById(id);
        }

        [HttpGet]
        [Route("byname/{name}")]
        public IEnumerable<User> GetByName(string name)
        {
            return _User.GetUserByName(name);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User value)
        {
            _User.AddUser(value);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public int Put(int id, [FromBody] User value)
        {
            string result = null;
           result=  _User.UpdateUser(id, value);

            if (result.Equals("Done")) return StatusCodes.Status200OK;
            else if (result.Contains("found")) return StatusCodes.Status204NoContent;
            return 0;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            string result = _User.DeleteUser(id);
            return result;
        }
    }
}
