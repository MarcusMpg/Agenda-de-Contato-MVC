using Agenda_de_Contato.Data;
using Agenda_de_Contato.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
ServiceProvider provide = builder.Services.BuildServiceProvider();
var configuration = provide.GetRequiredService<IConfiguration>();


// Add services to the container.

builder.Services.AddDbContext<BancoContext>(o =>o.UseSqlServer(configuration.GetConnectionString("DataBase")));
builder.Services.AddScoped<IContatoRepositorio, ContatosRepositorio>();

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
