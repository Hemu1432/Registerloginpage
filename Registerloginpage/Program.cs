using Microsoft.AspNetCore.Identity;
using Registerloginpage.Claims;
using Registerloginpage.Models;
using Registerloginpage.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Sample6Context>();
builder.Services.AddIdentity<Applicationuser, IdentityRole>().AddEntityFrameworkStores<Sample6Context>();
builder.Services.AddScoped<IAccountrepository,Accountrepository>();
builder.Services.ConfigureApplicationCookie(config =>
    config.LoginPath = "/login"
);
builder.Services.AddScoped<IUserClaimsPrincipalFactory<Applicationuser>, ApplicationUserClaimsPrincipleFactory>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
