using Microsoft.EntityFrameworkCore;
using SggApp.API.Contextos;
using SggApp.BLL.Interfaces;
using SggApp.BLL.Servicios;
using SggApp.DAL.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar servicios de Razor Pages
builder.Services.AddRazorPages();

// 2. Registrar tu DbContext
builder.Services.AddDbContext<SggAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// 3. Registrar repositorio + servicio
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddControllersWithViews();
// (Opcional) si también necesitas MVC controllers + views
// builder.Services.AddControllersWithViews();
// Servicios de negocio

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();


// Rutas MVC por defecto: /{controller=Home}/{action=Index}/{id?}
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Usuarios}/{action=Index}/{id?}"
);




app.Run();