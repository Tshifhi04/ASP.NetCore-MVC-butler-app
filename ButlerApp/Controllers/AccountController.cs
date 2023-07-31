using ButlerApp.Data;
using ButlerApp.Models;
using ButlerApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ButlerApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }
        [HttpGet]
        public IActionResult Profile()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            var responce = new LoginVM();
            return View(responce);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {

                var user = await _userManager.FindByEmailAsync(loginVM.Email);
                if (user != null)
                {
                    var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                    if (passwordCheck)
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");

                        }
                        TempData["Error"] = "wrong credentials entered";
                        return View(loginVM);
                    }

                }
            }
            TempData["Error"] = "wrong credentials entered";
            return View(loginVM);
        }
    }
}
