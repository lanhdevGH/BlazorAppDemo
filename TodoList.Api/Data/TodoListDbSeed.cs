using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.WebSockets;
using TodoList.Api.Entities;
using TodoList.Lib.Enums;

namespace TodoList.Api.Data
{
    public static class TodoListDbSeed
    {
        private static readonly IPasswordHasher<User> _passwordHasher = new PasswordHasher<User>();
        public static async Task SeedData(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<TodoListDb>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<Role>>();

                context.Database.Migrate();

                // Seed roles
                if (!context.Roles.Any())
                {
                    await roleManager.CreateAsync(new Role { Name = "Admin"});
                    await roleManager.CreateAsync(new Role { Name = "User" });
                }

                // Seed user
                if (!context.Users.Any())
                {
                    var adminUser = new User { UserName = "thanhlanh", Email = "thanhlanh@gmail.com" };
                    await userManager.CreateAsync(user: adminUser, password: _passwordHasher.HashPassword(user: adminUser, "Lanh010702"));
                    await userManager.AddToRoleAsync(user: adminUser, role: "Admin");

                    var normalUser = new User { UserName = "anhnguyet", Email = "anhnguyet@gmail.com" };
                    await userManager.CreateAsync(user: normalUser, password: _passwordHasher.HashPassword(user: adminUser, "Lanh010702"));
                    await userManager.AddToRoleAsync(user: normalUser, role: "User");
                }

                // Seed tasks
                if (!context.MyTasks.Any())
                {
                    var user = await userManager.FindByEmailAsync("thanhlanh@gmail.com");

                    context.MyTasks.Add(new MyTask
                    {
                        Id = Guid.NewGuid(),
                        Name = "Sample Task init 1",
                        Description = "These is init new task from code by NTL",
                        AssigneeID = user == null ? user.Id : null,
                        CreatedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        Priority = Priority.Low,
                        Status = Status.New,
                    });
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
