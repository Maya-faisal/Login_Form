using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Login_Page.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<StudentService>();


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("Data Source=(localdb)\\DESKTOP-6HDMF1P\\SQLSERVER;Initial Catalog=DB1;Integrated Security=True");
});

//Data source -> server Name
//Initial Catalog -> DataBase Name
//Integrated Security -> authe. No need for pass and username


builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=login}/{id?}");

app.MapControllerRoute(
    name: "HomePage",
    pattern: "{controller=Home}/{action=Index}");

app.MapControllerRoute(
    name: "form",
    pattern: "{controller=Home}/{action=form}");

app.MapControllerRoute(
    name: "storedata",
    pattern: "{controller=Home}/{action=storedata}");

app.MapControllerRoute(
    name: "dataTable",
    pattern: "{controller=Home}/{action=dataTable}");

app.MapControllerRoute(
    name: "EditData",
    pattern: "{controller=Home}/{action=EditData}");



app.Run();
