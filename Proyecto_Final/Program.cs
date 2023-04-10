using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;

using Proyecto_Final.Data;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;


using Proyecto_Final.Models;
using Proyecto_Final.BLL;
using BlazorStrap;
using Blazored.Toast;
using Proyecto_Final.Areas.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<Usuarios>(options =>{
    
     options.SignIn.RequireConfirmedAccount = false;
      options.Password.RequireDigit = false;
       options.Password.RequiredLength = 4;
       options.Password.RequireLowercase = false;
       options.Password.RequireNonAlphanumeric = false;
       options.Password.RequireUppercase = false;
       })
    .AddEntityFrameworkStores<ApplicationDbContext>();
  // Inyectando el Toast
builder.Services.AddBlazoredToast();
builder.Services.AddTransient<SuplidorBLL>();
builder.Services.AddTransient<UsuariosBLL>();
builder.Services.AddTransient<CategoriaBLL>();
builder.Services.AddTransient<PagoBLL>();
builder.Services.AddTransient<FacturaBLL>();

builder.Services.AddRazorPages();
builder.Services.AddBlazorStrap();

builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<Usuarios>>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
