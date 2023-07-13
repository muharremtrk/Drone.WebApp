using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Drone.WebApp.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Yapılandırma dosyasını ekleyin
builder.Configuration.AddJsonFile("appsettings.json");

// Servisleri burada yapılandırın
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddLogging();
builder.Services.AddDbContext<ZihalarContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), new MySqlServerVersion(new Version(8, 0, 26))));

// Diğer servis yapılandırmalarınızı buraya ekleyin

var app = builder.Build();

// Uygulama ortamını burada yapılandırın
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles(); // Statik dosyaları kullanılabilir hale getir

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
