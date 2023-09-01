using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DotSQL.Data;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

// Added this
//
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//var connection = String.Empty;
//if (builder.Environment.IsDevelopment())
//{
//    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
//    connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
//}
//else
//{
//    connection = Environment.GetEnvironmentVariable("AZURE_SQL_CONNECTIONSTRING");
//}

//builder.Services.AddDbContext<PersonDbContext>(options =>
//    options.UseSqlServer(connection));
builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));   //replaced
///// Ends added section
///

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();  //Added by XinXin

var app = builder.Build();

//app.MapGet("/", () => "Hello World!");

// Configure the HTTP request pipeline.  From youtube
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




//Added this section
//app.MapGet("/Person", (PersonDbContext context) =>
//{
//    return context.Person.ToList();
//})
//.WithName("GetPersons")
//.WithOpenApi();

//app.MapPost("/Person", (Person person, PersonDbContext context) =>
//{
//    context.Add(person);
//    context.SaveChanges();
//})
//.WithName("CreatePerson")
//.WithOpenApi();
///// Ends added section

// from youtube
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();


// Added this section
//public class Person
//{
//    public int Id { get; set; }
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//}

//public class PersonDbContext : DbContext
//{
//    public PersonDbContext(DbContextOptions<PersonDbContext> options)
//        : base(options)
//    {
//    }

//    public DbSet<Person> Person { get; set; }
//}
//// Ends the added section