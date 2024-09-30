using Devopsweb.Data;
using DotNetEnv;
using Microsoft.AspNetCore.Components.Sections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
Env.Load();

builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;


connectionString = connectionString
    .Replace("${DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST") ?? string.Empty)
    .Replace("${DB_DATABASE}", Environment.GetEnvironmentVariable("DB_DATABASE") ?? string.Empty)
    .Replace("${DB_USERNAME}", Environment.GetEnvironmentVariable("DB_USERNAME") ?? string.Empty)
    .Replace("${DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD") ?? string.Empty);
builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

string newConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

string hardcoded = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=password;";


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(newConnectionString));

builder.Services.AddDbContext<SkillsDbContext>(options =>
    options.UseNpgsql(newConnectionString));



builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();



var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
