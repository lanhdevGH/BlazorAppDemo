using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Lib.Enums;

namespace TodoList.Lib.DTO
{
    public class TaskSearch
    {
        public string? Name { get; set; }
        public Guid? AssigneeID { get; set; }
        public Priority? Priority { get; set; }
        public Status? Status { get; set; }
    }
}
