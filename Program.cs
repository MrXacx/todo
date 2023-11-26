using Microsoft.EntityFrameworkCore;
using todo.Data;
using Microsoft.Extensions.DependencyInjection;
using todo.Repository;
using todo.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultDatabase");
builder.Services.AddDbContext<TodoContext>(opt =>
{
    opt.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection));
});

builder.Services.AddScoped<ITodoRepository<UserModel>, UserRepository>();
builder.Services.AddScoped<ITodoRepository<TaskModel>, TaskRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();