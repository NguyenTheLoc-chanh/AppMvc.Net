## Controller
- Là một lớp kết thừa lớp Controller: Microsoft.AspNetCore.Mvc.Controller
- Action trong controller là một phương thức public (không được static)
- Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ inject vào controller qua hàm tạo

## View
- Là file .cshtml
- View cho Action lưu tại: View/ControllerName/ActionName.cshtml
- Thêm thư mực lưu trữ View:
```
    // {0} -> Name Action
    // {1} -> Name Controller
    // {2} -> Name Area
    options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
```
## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData

## Areas
- Là tên dùng để Routing
- Là cấu trúc thư mục chứa MVC
- Thiết lập Area cho Controller bằng ```[Area("AreaName")]```

```
dotnet aspnet-codegenerator area Product