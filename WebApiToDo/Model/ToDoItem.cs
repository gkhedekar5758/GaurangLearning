using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiToDo.Model
{
    public class ToDoItem
    {
        public int id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public int isCompleted { get; set; }
        public DateTime LastModifiedAt { get; set; }
        [Required]
        public int UserId { get; set; }
    }
}
