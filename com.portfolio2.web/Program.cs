using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using com.portfolio2.web.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using com.portfolio2.web.Filters;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<comportfolio2webContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("comportfolio2webContext") ?? throw new InvalidOperationException("Connection string 'comportfolio2webContext' not found.")));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                    config.LoginPath = "/Users/Login"; // Path for the redirect to user login page    
                    config.AccessDeniedPath = "/home/AccessDenied";
                });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("admin", policy => policy.RequireRole("admin"));


    options.AddPolicy("viewer",
        policy => policy.RequireRole("admin", "viewer")
        );

    options.FallbackPolicy = new AuthorizationPolicyBuilder()
       .RequireAuthenticatedUser()
       .Build();
});

builder.Services.AddMvc((options) =>
{
    //registering filter globally in every controllers and its action
    options.Filters.Add(typeof(MVCAuthorizationFilter));
    options.Filters.Add(typeof(MyActionFilter));
    options.Filters.Add(typeof(MyActionResultFilter));
    options.Filters.Add(typeof(MyExceptionFilter));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
