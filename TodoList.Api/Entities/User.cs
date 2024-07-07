using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TodoList.Api.Entities
{
    public class User : IdentityUser<Guid>
    {
        [MaxLength(200)]
        public string? FirstName { get; set; }

        [MaxLength(200)]
        public string? LastName { get; set; }
    }
}
