using System.ComponentModel.DataAnnotations;
using TodoList.Lib.Enums;

namespace TodoList.Lib.DTO
{
    public class TaskCreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage ="Bắc buộc nhập")]
        [MaxLength(20, ErrorMessage = "Nhập tối đa 20 ký tự")]
        public string TaskName { get; set; }
        [Required(ErrorMessage = "Bắc buộc nhập")]
        [MaxLength(200, ErrorMessage = "Nhập tối đa 200 ký tự")]
        public string TaskDescription { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }
    }
}
