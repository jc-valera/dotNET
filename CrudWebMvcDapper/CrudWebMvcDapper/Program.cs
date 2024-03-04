using Jcvalera.Core.BLL;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;
using System.Configuration;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUserBLL, UserBLL>();

//var sqlConnection = new SqlConfiguration(builder.Configuration.GetConnectionString("DbConneciton"));
//builder.Services.AddSingleton(sqlConnection);

builder.Services.AddSingleton(new SqlConfiguration(builder.Configuration.GetConnectionString("DbConnection")));

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
