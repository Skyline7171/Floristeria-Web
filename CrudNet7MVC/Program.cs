using FloristeriaWeb.Datos;
using FloristeriaWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuramos la conexi�n a sql ser local db MSSQLLOCAL
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // El carrito expira en 30 min de inactividad
    options.Cookie.HttpOnly = true; // Seguridad: la cookie no es accesible v�a JS
    options.Cookie.IsEssential = true; // Necesaria para que la app funcione
});

// 1. Configuraci�n de Identity (Usa tus clases de contexto)
builder.Services.AddDefaultIdentity<UsuarioAplicacion>(options => {
    options.SignIn.RequireConfirmedAccount = false; // Para desarrollo es más fácil así
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

var googleClientId = builder.Configuration["Authentication:Google:ClientId"]
    ?? throw new InvalidOperationException("Falta el ClientId de Google en la configuraci�n.");

var googleClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]
    ?? throw new InvalidOperationException("Falta el ClientSecret de Google en la configuraci�n.");

// 2. Configuraci�n de Autenticaci�n Externa (Google)
builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
        // Estos los obtendr�s de la consola de Google en el siguiente paso
        googleOptions.ClientId = googleClientId;
        googleOptions.ClientSecret = googleClientSecret;
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

app.UseRouting();

app.UseSession();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
