using AppMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AppMvc.Net.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        // GET: Product
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public ActionResult Index()
        {
            var product = _productService.OrderBy(p => p.Name).ToList();
            return View(product);
        }

    }
}
