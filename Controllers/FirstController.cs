using AppMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers;
public class FirstController : Controller
{
    private readonly ILogger<FirstController> _logger;
    private readonly ProductService _productService;
    public FirstController(ILogger<FirstController> logger, ProductService productService){
        _logger = logger;
        _productService = productService;
    }
    public string Index() {
        // this.HttpContext
        // this.Request
        // this.Response
        // this.RouteData

        // this.User
        // this.ModelState
        // this.ViewData
        // this.ViewBag
        // this.Url
        _logger.LogInformation("Index Action");
        return "Tôi là First Controller!";
    }
    public IActionResult HelloView()
    {
        // View() -> Razor Engine, doc .cshtml (template)
        return View();
    }

    public IActionResult ViewProduct(int? id)
    {
        var product = _productService.Where(p => p.Id == id).FirstOrDefault();
        if(product == null)
        {
            TempData["StatusMessage"] = "Sản phẩm không tồn tại!";
            return RedirectToAction("Index","Home");
        }

        // Truyền dữ liệu sang view bằng Model
        // return View(product);

        // ViewData
        // this.ViewData["Product"] = product;
        // ViewData["Title"] = product.Name;
        // return View("Viewproduct2");

        // ViewBag
        ViewBag.product = product;
        return View("Viewproduct3");
    }
}