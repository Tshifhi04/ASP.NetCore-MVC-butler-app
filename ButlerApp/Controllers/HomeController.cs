using ButlerApp.Data;
using ButlerApp.Models;
using ButlerApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ButlerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task< IActionResult> Index()
        {
            int butlerCount = await _context.Butlers.CountAsync();
            int userCount = await _context.Users.CountAsync();

            var viewModel = new DashboardViewModel
            {
                ButlerCount = butlerCount,
                UserCount = userCount
            };

            return View(viewModel);
        }

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}