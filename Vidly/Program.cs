using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

var builder = WebApplication.CreateBuilder(args);
// configure the connection string 

builder.Services.AddDbContext<ApplicationDbContext>
        (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// configure the Identity 

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

// google auth

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = "Identity.Application";
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
        .AddCookie()
        .AddGoogle(opts =>
        {
            opts.ClientId = builder.Configuration["Authentication:Google:ClientId"];
            opts.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
            opts.SignInScheme = IdentityConstants.ExternalScheme;
        });


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
    pattern: "{controller=Account}/{action=Login}/{id?}");


app.Run();
