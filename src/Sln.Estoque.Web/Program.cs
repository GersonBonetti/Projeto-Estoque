using Microsoft.EntityFrameworkCore;
using Sln.Estoque.Application.Service.SQLServerServices;
using Sln.Estoque.Domain.IRepositories;
using Sln.Estoque.Domain.IServices;
using Sln.Estoque.Infra.Data.Context;
using Sln.Estoque.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Context SQL Server
builder.Services.AddDbContext<SQLServerContext>
  /*(options => options.UseSqlServer("Server=DESKTOP-D0PM9M5\\SQLEXPRESS;Database=Estoque;User Id=sa;Password=YF2023!;TrustServerCertificate=True;"));*/ // Zeso
  /*(options => options.UseSqlServer("Server=DESKTOP-SOE91L9\\SQLEXPRESS;Database=Estoque;User Id=sa;Password=YF2023!;TrustServerCertificate=True;")); // Gabzera*/
  (options => options.UseSqlServer("Server=LAPTOP-J7OCOHCR\\SQLEXPRESS;Database=Estoque;User Id=sa;Password=admin;TrustServerCertificate=True;")); // ZesoCasa

// ### Dependency Injection
// # Repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

// # Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
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
