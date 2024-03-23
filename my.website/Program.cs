using Microsoft.EntityFrameworkCore;
using my.website.Entities;
using my.website.Services;
using my.website.Services.Abstract;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyWebsiteDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("MsSQLConnection")));

builder.Services.AddSingleton<IEmailService, EmailService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}"); 

app.Run();
