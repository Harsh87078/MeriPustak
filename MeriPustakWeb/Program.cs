using MeriPustak.DataAccess.Data;
using MeriPustak.DataAccesss.Repository;
using MeriPustak.DataAccesss.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("dbcs");
builder.Services.AddDbContext<MeriPustakDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MeriPustakDbContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
