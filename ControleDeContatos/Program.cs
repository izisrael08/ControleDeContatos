    using Microsoft.EntityFrameworkCore;
    using ControleDeContatos.Data;
    using ControleDeContatos.Repositorio;
    using ControleDeContatos.Helper;

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    // Adicionando o DbContext com a string de conexão configurada
    builder.Services.AddDbContext<BancoContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

    // Registrando os repositórios
    builder.Services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
    builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>(); // Certifique-se de que UsuarioRepositorio implementa IUsuarioRepositorio

    // Registrando o IHttpContextAccessor corretamente como Singleton
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddScoped<ISessao, Sessao>();

    // Adicionando o serviço de sessão
    builder.Services.AddSession(options =>
    {
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
        //options.IdleTimeout = TimeSpan.FromMinutes(30); // Define o tempo de expiração da sessão
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
    app.UseStaticFiles();

    app.UseRouting();

    // Habilita o uso de sessões
    app.UseSession();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Login}/{action=Index}/{id?}");

    app.Run();
