using Microsoft.EntityFrameworkCore;
using ControleDeContatos.Data;
using ControleDeContatos.Repositorio;
// Importar o namespace correto para o seu BancoContext
// Certifique-se de importar o namespace correto para IUsuarioRepositorio

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Adicionando o DbContext com a string de conexão configurada
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

// Registrando o repositório contatos
builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();  // Certifique-se de que UsuarioRepositorio implementa IUsuarioRepositorio

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
