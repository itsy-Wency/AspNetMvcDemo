using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspNetMvcDemo.Filters;


var builder = WebApplication.CreateBuilder(args);

// Register MVC services (controllers + views)
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<DemoActionFilter>();
});



// Register session services (server-side state storage)
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    // session idle timeout (how long the session lasts when idle)
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.HttpOnly = true; // cookie can't be read by client-side JS
    options.Cookie.IsEssential = true; // cookie is essential for the app
});

var app = builder.Build();

// Middleware pipeline: order matters
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // redirect HTTP to HTTPS
app.UseStaticFiles(); // serve files from wwwroot (css/js/images)

// Routing middleware
app.UseRouting();

// Use session BEFORE mapping routes so controllers can access session
app.UseSession();

app.UseAuthorization();

// Default route: / => Home/Index
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Form}/{action=Index}/{id?}");

app.Run();
