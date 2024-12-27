using AppMvc.Services;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));
builder.Services.Configure<RazorViewEngineOptions>(options => {
    // /View/Controller/Action.cshtml
    // /MyView/Controller/Action.cshtml

    // {0} -> Name Action
    // {1} -> Name Controller
    // {2} -> Name Area
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
});
builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));

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

app.UseAuthorization(); // Xác định quyền truy cập

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
 
app.Run();
