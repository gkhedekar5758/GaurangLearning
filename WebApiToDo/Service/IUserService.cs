using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.Model;

namespace WebApiToDo.Service
{
    public interface IUserService
    {
        public IEnumerable<User> GetUsers();
        public User GetUserById(int id);
        public IEnumerable<User> GetUserByName(string name);
        public void AddUser(User user);
        public string UpdateUser(int id, User user);
        public string DeleteUser(int id);

    }
}
