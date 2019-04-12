using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime DueData { get; set; }
        public bool Status { get; set; }
        public int Priority { get; set; }
        public string Attachment { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}