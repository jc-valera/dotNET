using BlazorCRUD.Components;
using Jcvalera.Core.BLL;
using Jcvalera.Core.Common.Services;
using Jcvalera.Core.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IUserBLL, UserBLL>();

var sqlConn = new SqlConfiguration(builder.Configuration.GetConnectionString("DbConnection"));
builder.Services.AddSingleton(sqlConn);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
