using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApiToDo.Model;

namespace WebApiToDo.Data
{
    public class PracticeDBContext : DbContext
    {
        public PracticeDBContext(DbContextOptions<PracticeDBContext> options) :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<ToDoItem> toDoItems { get; set; }

        #region User
        public List<User> getUsersFromDB() => Users.ToList();
        
        public User GetSingleUserByIdFromDB(int id)
        {
            var item=from p in Users where p.userId==id select p;
            return item.FirstOrDefault();//  as User;
            //return null;
        }

       
        public void addUserInDB(User user)
        {
            Users.Add(user);
            this.SaveChanges();
            return;
        }

        public List<User> GetUsersByNameDB(string name)
        {
            var item = Users.Where(p => p.firstName.Contains(name)).ToList();
            return item;//.FirstOrDefault():
        }
        
        public string UpdateUserDB(int id,User user)
        {
            var userfromDB = Users.Where(user => user.userId == id).FirstOrDefault();

            if (userfromDB != null)
            {
                userfromDB.userId = user.userId;
                userfromDB.firstName = user.firstName;
                userfromDB.lastName = user.lastName;
                userfromDB.phoneNumber = user.phoneNumber;
                userfromDB.emailAddress = user.emailAddress;
                this.SaveChanges();
                return "Done";
            }
            else
                return "User was not found";
               
            
        }
        public string DeleteUserDB(int id)
        {
            User user = Users.Where(user => user.userId == id).FirstOrDefault();
            if (user != null)
            {
                Users.Remove(user);
                this.SaveChanges();
                return "Done";
            }
            else
                return "Not Found";
            

        }

        #endregion

        #region todo
        public List<ToDoItem> getTodoFromDB() => toDoItems.ToList();

        public IEnumerable<ToDoItem> getToDOByStatus(int status)
        {
            return toDoItems.Where(item => item.isCompleted == status).ToList();
        }
        public void addTodoInDB(ToDoItem toDoItem)
        {
            toDoItems.Add(toDoItem);
            this.SaveChanges();
            return;
        }

        public IEnumerable<ToDoItem> getToDOByUser(int userid)
        {
            return toDoItems.Where(item => item.UserId == userid).ToList();
        }

        public string DeleteTodoDB(int id)
        {
            ToDoItem item = toDoItems.Where(user => user.id == id).FirstOrDefault();
            if (item != null)
            {
                toDoItems.Remove(item);
                this.SaveChanges();
                return "Done";
            }
            else
                return "Not Found";


        }
        public string updateTodo(int id, ToDoItem toDoItem)
        {
            var userfromDB = toDoItems.Where(user => user.id == id).FirstOrDefault();

            if (userfromDB != null)
            {
                //userfromDB. = user.userId;
                userfromDB.Title = toDoItem.Title;
                userfromDB.Description = toDoItem.Description;
                userfromDB.isCompleted = toDoItem.isCompleted;
                userfromDB.LastModifiedAt = toDoItem.LastModifiedAt;
                userfromDB.UserId = toDoItem.UserId;
                this.SaveChanges();
                return "Done";
            }
            else
                return "User was not found";
        }
        #endregion
    }
}
