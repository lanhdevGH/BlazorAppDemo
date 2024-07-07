using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoList.Api.Configurations;
using TodoList.Api.Data;
using TodoList.Api.Entities;

var builder = WebApplication.CreateBuilder(args);

// ConnectDb
var connectDbConfig = new ConnectionDB();
builder.Configuration.GetSection("ConnectionStrings:DefaultConnection").Bind(connectDbConfig);
builder.Services.AddDbContext<TodoListDb>(option => option.UseSqlServer(connectDbConfig.GetConnectionString()));
/*
 Dòng lệnh này đăng ký ConnectionDB với hệ thống DI 
và cấu hình nó bằng cách đọc các giá trị từ appsettings.json. 
Điều này giúp bạn có thể inject ConnectionDB vào các dịch vụ khác nếu cần thiết
 */
builder.Services.Configure<ConnectionDB>(builder.Configuration.GetSection("ConnectionStrings:DefaultConnection"));

// Add Identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<TodoListDb>()
    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Seed data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TodoListDb>();
        context.Database.Migrate(); // Apply any pending migrations
        TodoListDbSeed.SeedData(services).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
