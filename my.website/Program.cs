using Microsoft.EntityFrameworkCore;
using my.website.Data;
using my.website.Entities;
using my.website.Services;
using my.website.Services.Abstract;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseUrls("https://localhost:7155");

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Identity yapılandırması
builder.Services.AddIdentityCore<Users>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MyWebsiteDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddHttpClient();

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

// Kimlik doğrulama ara yazılımını kullanılabilir hale getirme
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");
app.Run();
