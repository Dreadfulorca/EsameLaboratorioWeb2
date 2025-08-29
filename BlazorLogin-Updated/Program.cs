using BlazorServerAuthenticationAndAuthorization.Authentication;
using BlazorServerAuthenticationAndAuthorization.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using BlazorServerAuthenticationAndAuthorization.Models;
using BlazorServerAuthenticationAndAuthorization.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AuthDbContext>(options =>
options.UseSqlite("Data Source=auth.db"));

builder.Services.AddScoped<UserAccountService>();

builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<UserAccountService>();
builder.Services.AddScoped<PrenotazioneService>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("NotAdmin", policy =>
        policy.RequireAssertion(ctx =>
            // true se NON è Admin (copre sia anonimi sia utenti non-Admin)
            !ctx.User.IsInRole("Administrator")));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
