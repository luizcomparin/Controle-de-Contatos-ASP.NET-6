using Controle_de_Contatos.Data;
using Controle_de_Contatos.Repositorio;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEntityFrameworkSqlServer()
	.AddDbContext<BancoContext>(options => options.UseSqlServer("name=ConnectionStrings:DataBase"));
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();  // Toda vez que "IContatoRepositorio" for instanciada, será substituída por "ContatoRepositório".
																		// Isto é "Injeção de Dependência".


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
