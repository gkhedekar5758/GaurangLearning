using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApiToDo.Model
{
    public class User
    {
        public int userId { get; set; }
        [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        public int phoneNumber { get; set; }
        [EmailAddress]
        public string emailAddress { get; set; }
    }
}
