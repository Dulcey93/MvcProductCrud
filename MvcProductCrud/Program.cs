using Microsoft.EntityFrameworkCore;
using MvcProductCrud.Data;

var builder = WebApplication.CreateBuilder(args);

// 🧩 Configuración del DbContext con conexión a SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppDbContext")
        ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.")
    ));

// 🧩 Agregar servicios MVC al contenedor (Controladores + Vistas)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// 🌐 Configuración del middleware HTTP
if (!app.Environment.IsDevelopment())
{
    // En producción: manejo global de errores
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts(); // 👈 Seguridad: Strict-Transport-Security
}

app.UseHttpsRedirection(); // 👈 Redirige HTTP → HTTPS
app.UseStaticFiles();      // 👈 Habilita archivos estáticos como CSS, JS, imágenes

app.UseRouting();          // 👈 Habilita enrutamiento

app.UseAuthorization();    // 👈 Para autenticación (aunque no se usa aún)

// 🧭 Ruta modificada para ver el CRUD al iniciar
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");


app.Run();

