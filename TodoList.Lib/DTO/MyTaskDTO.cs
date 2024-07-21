using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Api.Enums;

namespace TodoList.Lib.DTO
{
    public class MyTaskDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? AssigneeID { get; set; }
        public string? AssigneeName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
    }
}
