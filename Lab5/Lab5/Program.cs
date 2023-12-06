using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.DependencyInjection;
using Okta.AspNetCore;
using Lab5.Models;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://*:7047");

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

builder.Services.AddAuthentication(authOptions =>
{
    authOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    authOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie()
.AddOktaMvc(new OktaMvcOptions
{
    AuthorizationServerId = "default",
    ClientId = "0oadnw7zfmAMS9mpJ5d7",
    OktaDomain = "https://dev-95822749.okta.com",
    ClientSecret = "QQ-z7D_yuGmyYjLay1WYvBh53VxQcXpipfQfENlkhxhrbQxpRrKZK3oo9yGSYUY6",
    Scope = new List<string> { "openid", "profile", "email", "phone" },
});

builder.Services.AddAuthorization();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
