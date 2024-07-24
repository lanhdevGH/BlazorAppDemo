using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoList.Lib.Enums;

namespace TodoList.Api.Entities
{
    public class MyTask
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid? AssigneeID { get; set; }

        [ForeignKey("AssigneeID")]
        public User? Assignee { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set;}
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        
    }
}
