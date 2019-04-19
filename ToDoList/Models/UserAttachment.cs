using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class UserAttachment
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }

        public virtual UserTask UserTask { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}