using backgroundservice.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Servisleri ekleme
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();

// Veritabaný baðlantýsýný ve DbContext'i ekleme
var connectionString = builder.Configuration.GetConnectionString("Defaultconnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// HTTP istek iþlem hattýný yapýlandýrma
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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