using FloristeriaWeb.Datos;
using FloristeriaWeb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuramos la conexión a sql ser local db MSSQLLOCAL
builder.Services.AddDbContext<ApplicationDbContext>(opciones => opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // El carrito expira en 30 min de inactividad
    options.Cookie.HttpOnly = true; // La cookie no es accesible vía JS
    options.Cookie.IsEssential = true; // Necesario para que la app funcione
});

// 1. Configuración de Identity
builder.Services.AddDefaultIdentity<UsuarioAplicacion>(options => {
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

var googleClientId = builder.Configuration["Authentication:Google:ClientId"]
    ?? throw new InvalidOperationException("Falta el ClientId de Google en la configuraci�n.");

var googleClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]
    ?? throw new InvalidOperationException("Falta el ClientSecret de Google en la configuraci�n.");

// 2. Configuración de Autenticación Externa (Google)
builder.Services.AddAuthentication()
    .AddGoogle(googleOptions =>
    {
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

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UsuarioAplicacion>>();

    // Asegura que el rol Admin exista
    string[] nombresRoles = { "Admin", "Cliente" };
    foreach (var nombreRol in nombresRoles)
    {
        var elRolExiste = await roleManager.RoleExistsAsync(nombreRol);
        if (!elRolExiste)
        {
            await roleManager.CreateAsync(new IdentityRole(nombreRol));
        }
    }

    // Aquí se debe configurar el correo que obtendrá el rol de Admin
    var correoAdmin = "xpolargeist007x@gmail.com";
    var usuarioAdmin = await userManager.FindByEmailAsync(correoAdmin);

    if (usuarioAdmin != null)
    {
        // Verifica si el usuario ya tiene el rol para no duplicarlo
        var yaEsAdmin = await userManager.IsInRoleAsync(usuarioAdmin, "Admin");
        if (!yaEsAdmin)
        {
            await userManager.AddToRoleAsync(usuarioAdmin, "Admin");
        }
    }
}

app.Run();
