using AppMvc.Services;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
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
builder.Services.AddSingleton<PlanetService>();

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
//app.AddStatusCodePage(); // Tùy biến response Lỗi: 400 - 599

app.UseRouting();

app.UseAuthorization(); // Xác định quyền truy cập

// app.MapControllers();
// app.MapDefaultControllerRoute();
// app.MapAreaControllerRoute();

app.MapAreaControllerRoute(
    name: "product",
    areaName: "ProductManage",
    pattern: "{controller}/{action=Index}/{id?}"
);
// Sử dụng cho Controller không có Area
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
 
app.Run();
