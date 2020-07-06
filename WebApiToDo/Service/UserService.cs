using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiToDo.Model;
using Microsoft.AspNetCore.Hosting;
using System.Text.Json;
using WebApiToDo.Data;

namespace WebApiToDo.Service
{
    public class UserService : IUserService
    {
        private IEnumerable<User> _users;
        private string Userfilepath = @"C:\Users\GKHEDEKAR\source\repos\WebApiToDo\WebApiToDo\MockData\json.json";
        PracticeDBContext database = null;
        public UserService(IWebHostEnvironment webHostEnvironment,PracticeDBContext dBContext)
        {
            database = dBContext;
            //var Userfilepath = @$"{webHostEnvironment.ContentRootPath}\MockData\json.json";
            // C:\Users\GKHEDEKAR\source\repos\WebApiToDo\WebApiToDo\MockData
            var content = System.IO.File.ReadAllText(Userfilepath);
            _users = JsonSerializer.Deserialize<IEnumerable<User>>(content);

        }
        public void AddUser(User user)
        {
            #region file
            //string json = System.IO.File.ReadAllText(Userfilepath);
            //List<User> Users = JsonSerializer.Deserialize<List<User>>(json);
            //Users.Add(user);

            //System.IO.File.WriteAllText(Userfilepath, JsonSerializer.Serialize(Users));
            #endregion
            #region DB
            database.addUserInDB(user);
            #endregion

        }

        public string DeleteUser(int id)
        {
            #region file
            //if (_users.FirstOrDefault(u=>u.userId==id)!=null)
            //{
            //    _users = _users.Where(u => u.userId != id).ToList();
            //    System.IO.File.WriteAllText(Userfilepath, JsonSerializer.Serialize(_users));
            //    return "Done";
            //}
            //else return "Could not delete";
            #endregion
            #region db
            return database.DeleteUserDB(id);
            #endregion

        }

        public User GetUserById(int p)
        {
            #region DB
            return database.GetSingleUserByIdFromDB(p);
            #endregion
            #region file
            //return _users.Where(user => user.userId == p).SingleOrDefault();
            #endregion
        }

        public IEnumerable<User> GetUserByName(string name)
        {
            #region db
            return database.GetUsersByNameDB(name);
            #endregion
            #region file
            //return _users.Where(user => user.firstName.Contains(name, StringComparison.CurrentCultureIgnoreCase) || user.lastName.Contains(name, StringComparison.CurrentCultureIgnoreCase)); //.FirstOrDefault();
            #endregion
        }

        public IEnumerable<User> GetUsers()
        {
            #region dbregion
            return database.getUsersFromDB();
            #endregion
            #region file
            //return _users;
            #endregion
        }

        public string UpdateUser(int id, User user)
        {
            #region file
            //User userFromFIle = _users.Where(user => user.userId == id).SingleOrDefault();

            //if(userFromFIle!=null)
            //{
            //    userFromFIle.userId = user.userId;
            //    userFromFIle.firstName = user.firstName;
            //    userFromFIle.lastName = user.lastName;
            //    userFromFIle.phoneNumber = user.phoneNumber;
            //    userFromFIle.emailAddress = user.emailAddress;

            //    //_users.ToList().Remove(_users.Where(user => user.userId == id).SingleOrDefault());
            //    //_users.ToList().Add(userFromFIle);

            //    string op = JsonSerializer.Serialize(_users);
            //    System.IO.File.WriteAllText(Userfilepath, op);

            //    return "Done";
            //}
            //else
            //{
            //    return "NotFound";
            //}
            #endregion
            #region db
            string returnString;
            returnString = database.UpdateUserDB(id, user);
            return returnString;
            #endregion
        }
    }
}
