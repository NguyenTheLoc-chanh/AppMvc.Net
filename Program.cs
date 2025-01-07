using App.Services;
using AppMvc.Models;
using AppMvc.Net.Models;
using AppMvc.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
            var mailsetting = builder.Configuration.GetSection("MailSettings");
            builder.Services.Configure<MailSettings>(mailsetting);
            builder.Services.AddSingleton<IEmailSender, SendMailService>();

// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(options => {
                string connectString = builder.Configuration.GetConnectionString("AppMvcConnectionString");
                options.UseSqlServer(connectString);
            });
// Đăng ký dịch vụ Identity
builder.Services.AddIdentity<AppUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDBContext>()
                    .AddDefaultTokenProviders();

// Truy cập IdentityOptions
builder.Services.Configure<IdentityOptions> (options => {
    // Thiết lập về Password
    options.Password.RequireDigit = false; // Không bắt phải có số
    options.Password.RequireLowercase = false; // Không bắt phải có chữ thường
    options.Password.RequireNonAlphanumeric = false; // Không bắt ký tự đặc biệt
    options.Password.RequireUppercase = false; // Không bắt buộc chữ in
    options.Password.RequiredLength = 3; // Số ký tự tối thiểu của password
    options.Password.RequiredUniqueChars = 1; // Số ký tự riêng biệt

    // Cấu hình Lockout - khóa user
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes (5); // Khóa 5 phút
    options.Lockout.MaxFailedAccessAttempts = 3; // Thất bại 3 lầ thì khóa
    options.Lockout.AllowedForNewUsers = true;

    // Cấu hình về User.
    options.User.AllowedUserNameCharacters = // các ký tự đặt tên user
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    options.User.RequireUniqueEmail = true;  // Email là duy nhất
            

    // Cấu hình đăng nhập.
    options.SignIn.RequireConfirmedEmail = true;            // Cấu hình xác thực địa chỉ email (email phải tồn tại)
    options.SignIn.RequireConfirmedPhoneNumber = false;     // Xác thực số điện thoại
    options.SignIn.RequireConfirmedAccount = true; 
                
    });    

builder.Services.ConfigureApplicationCookie(options => {
    options.LoginPath = "/login/";
    options.LogoutPath = "/logout/";
    options.AccessDeniedPath = "/khongduoctruycap.html";
    });  

// builder.Services.AddAuthentication()
//                     .AddGoogle(options => {
//                         var gconfig = Configuration.GetSection("Authentication:Google");
//                         options.ClientId = gconfig["ClientId"];
//                         options.ClientSecret = gconfig["ClientSecret"];
//                         // https://localhost:5001/signin-google
//                         options.CallbackPath =  "/dang-nhap-tu-google";
//                     })
//                     .AddFacebook(options => {
//                         var fconfig = Configuration.GetSection("Authentication:Facebook");
//                         options.AppId  = fconfig["AppId"];
//                         options.AppSecret = fconfig["AppSecret"];
//                         options.CallbackPath =  "/dang-nhap-tu-facebook";
//                     })
//                     // .AddTwitter()
//                     // .AddMicrosoftAccount()
//                     ;

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
builder.Services.AddSingleton<IdentityErrorDescriber, AppIdentityErrorDescriber>();

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
app.UseAuthentication(); // Xác định danh tính
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
