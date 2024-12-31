using AppMvc.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMvc.Net.Controllers;

[Area("Database")]
[Route("database-manage/[action]")]
public class DbManageController: Controller
{

    private readonly AppDBContext _dbContext;

    public DbManageController (AppDBContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IActionResult Index(){
        return View();
    }

    [HttpGet]
    public IActionResult DeleteDb()
    {
        return View();
    }

    [TempData]
    public string StatusMessage { get; set;}

    [HttpPost]
    public async Task<IActionResult> DeleteDbAsync()
    {
        var success = await _dbContext.Database.EnsureDeletedAsync();
        StatusMessage = success ? "Xóa DB thành công!" : "Không thể xóa DB";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Migrate()
    {
        await _dbContext.Database.MigrateAsync();
        StatusMessage = "Cập nhật database thành công!";
        return RedirectToAction(nameof(Index));
    }
}