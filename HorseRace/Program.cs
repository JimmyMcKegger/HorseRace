using HorseRace.Components;
using HorseRace.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// add db context
// https://www.youtube.com/watch?v=D8FWqT7Xvoo
builder.Services.AddDbContext<HorseRaceManagementContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("HorseRaceManagementContext")));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

const string AuthScheme = "hr-auth";
const string AuthCookie = "hr-auth";

builder.Services.AddAuthentication()
    .AddCookie(AuthScheme, options =>
    {
        options.Cookie.Name = AuthCookie;
        options.LoginPath = "/auth/login";
        options.AccessDeniedPath= "/auth/access-denied";
        options.LogoutPath = "/auth/logout";

        options.Cookie.httpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Strict;
        
        options.Cookie.Expiration = TimeSpan.FromDays(1);
    });
// https://www.youtube.com/watch?v=oBofp1QeGVQ

// add icons
builder.Services.AddBlazorBootstrap();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAuthentication()
    .UseAuthorization();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();