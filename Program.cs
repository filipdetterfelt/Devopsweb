using Devopsweb.Data;
using DotNetEnv;
using Microsoft.AspNetCore.Components.Sections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);


Env.Load();
string testenv = Environment.GetEnvironmentVariable("DB_HOST");
Console.WriteLine("Testenv = " + testenv);
string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"] ?? string.Empty;
Console.WriteLine("Connectionstring = " + connectionString);


// Replace placeholders with actual environment variables
connectionString = connectionString
    .Replace("${DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST") ?? string.Empty)
    .Replace("${DB_DATABASE}", Environment.GetEnvironmentVariable("DB_DATABASE") ?? string.Empty)
    .Replace("${DB_USERNAME}", Environment.GetEnvironmentVariable("DB_USERNAME") ?? string.Empty)
    .Replace("${DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD") ?? string.Empty);
Console.WriteLine(connectionString);
builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;
//Console.WriteLine(builder.Configuration["ConnectionStrings:DefaultConnection"]);

Console.WriteLine(Environment.GetEnvironmentVariable("DB_HOST"));
Console.WriteLine(Environment.GetEnvironmentVariable("DB_DATABASE"));
Console.WriteLine(Environment.GetEnvironmentVariable("DB_USERNAME"));
Console.WriteLine(Environment.GetEnvironmentVariable("DB_PASSWORD"));



string saveStringFromBuilder = builder.Configuration["ConnectionStrings:DefaultConnection"];
Console.WriteLine(connectionString);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDbContext<SkillsDbContext>(options =>
    options.UseNpgsql(connectionString));


// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(saveStringFromBuilder));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();



var app = builder.Build();
Console.WriteLine("Connectionstring after replace = " + builder.Configuration["ConnectionStrings:DefaultConnection"]);
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();



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
