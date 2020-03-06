using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab_63_ToDo_API_Users_Categories.Models
{
    public class ToDo
    {
        public int ToDoId { get; set; }
        public string ToDoName { get; set; }

        // add user as a foreign key
        public int? UserId { get; set; }
        public User User { get; set; }
    }
}
