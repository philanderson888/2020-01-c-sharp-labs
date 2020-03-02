using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace lab_60_cats_API.Models
{
    public class Cat
    {
        public int CatId { get; set; }
        public string CatName { get; set; }

        // Foreign Key : Each cat will have a category
        public int? CategoryId { get; set; }

        public Category Category { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        //[DisplayFormat.... show UK date]
        public DateTime DateOfBirth { get; set; }

    }
}
