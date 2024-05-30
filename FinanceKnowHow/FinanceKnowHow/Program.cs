using FinanceKnowHow.DBContext;
using FinanceKnowHow.Models;
using FinanceKnowHow.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<BlogPostService>();
builder.Services.AddDbContext<ApplicationDBContext>();
builder.Services.AddTransient<SearchInput>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddServerSideBlazor();

builder.Services.AddLogging();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Email", // Give it a unique name
        pattern: "Email/{action?}/{id?}", // Define the pattern for the URL
        defaults: new { controller = "EmailController" }); // Specify the controller name

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
    endpoints.MapBlazorHub();
});

app.Run();
