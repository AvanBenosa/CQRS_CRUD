using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS_MEDIATOR_CRUD.Model
{
    public class Todo
    {
        public int Id { get; set; }
        [Required]
        public string TaskName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Deadline { get; set; }
    }
}

 
