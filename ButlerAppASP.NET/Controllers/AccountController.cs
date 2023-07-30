using Microsoft.AspNetCore.Mvc;

namespace ButlerAppASP.NET.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
