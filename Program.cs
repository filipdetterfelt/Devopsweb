using Devopsweb.Data;
using DotNetEnv;
using Microsoft.AspNetCore.Components.Sections;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
Env.Load();


builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).AddEnvironmentVariables();

//string workingUrl = "Host = localhost; Port = 5432; Database = postgres; Username = postgres; Password = password;" ;




Console.WriteLine("DB_HOST: " + Environment.GetEnvironmentVariable("DB_HOST"));
Console.WriteLine("DB_DATABASE: " + Environment.GetEnvironmentVariable("DB_DATABASE"));
Console.WriteLine("DB_USERNAME: " + Environment.GetEnvironmentVariable("DB_USERNAME"));
Console.WriteLine("DB_PASSWORD: " + Environment.GetEnvironmentVariable("DB_PASSWORD"));



string connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
if (string.IsNullOrWhiteSpace(connectionString)) 
{
    Console.WriteLine("Connection string is empty");
}

connectionString = connectionString
    .Replace("${DB_HOST}", Environment.GetEnvironmentVariable("DB_HOST") ?? string.Empty)
    .Replace("${DB_DATABASE}", Environment.GetEnvironmentVariable("DB_DATABASE") ?? string.Empty)
    .Replace("${DB_USERNAME}", Environment.GetEnvironmentVariable("DB_USERNAME") ?? string.Empty)
    .Replace("${DB_PASSWORD}", Environment.GetEnvironmentVariable("DB_PASSWORD") ?? string.Empty);
builder.Configuration["ConnectionStrings:DefaultConnection"] = connectionString;

string newConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
Console.WriteLine("New connection string = " + newConnectionString.Length);

string hardcoded = "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=password;";
Console.WriteLine("Connection String after replacement: " + connectionString.Length);
Console.WriteLine("Hardcoded String " + hardcoded.Length);

//string testenv = Environment.GetEnvironmentVariable("DB_HOST");
//Console.WriteLine("Testenv = " + testenv);
//Console.WriteLine("Connectionstring = " + connectionString);


// Replace placeholders with actual environment variables
//Console.WriteLine(connectionString);

//Console.WriteLine(builder.Configuration["ConnectionStrings:DefaultConnection"]);

//Console.WriteLine(Environment.GetEnvironmentVariable("DB_HOST").Length);
//Console.WriteLine(Environment.GetEnvironmentVariable("DB_DATABASE").Length);
//Console.WriteLine(Environment.GetEnvironmentVariable("DB_USERNAME").Length);
//Console.WriteLine(Environment.GetEnvironmentVariable("DB_PASSWORD").Length);



//string saveStringFromBuilder = builder.Configuration["ConnectionStrings:DefaultConnection"];
//Console.WriteLine(connectionString);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(newConnectionString));

builder.Services.AddDbContext<SkillsDbContext>(options =>
    options.UseNpgsql(newConnectionString));


// Add services to the container.

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();



var app = builder.Build();
//Console.WriteLine("Connectionstring after replace = " + builder.Configuration["ConnectionStrings:DefaultConnection"]);



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
