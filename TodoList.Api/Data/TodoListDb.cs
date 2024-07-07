using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Entities;

namespace TodoList.Api.Data
{
    public class TodoListDb : IdentityDbContext<User,Role, Guid>
    {
        public TodoListDb(DbContextOptions<TodoListDb> options) : base(options)
        {
            
        }

        public DbSet<MyTask> MyTasks { get; set; }
    }
}
