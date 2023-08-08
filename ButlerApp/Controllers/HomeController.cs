using ButlerApp.Data;
using ButlerApp.Interfaces;
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
        private readonly IPhotoService _photoService;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context, IPhotoService photoService)
        {
            _logger = logger;
            _context = context;
            _photoService = photoService;
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

        [HttpGet]
        public async Task<IActionResult> AddButler()
        {
            return  View();
        }
        [HttpPost]
        public async Task<IActionResult> AddButler(ButlerVM butlerVM)
        {

            if (!ModelState.IsValid)
            {
               var result = await _photoService.AddPhotoAsync(butlerVM.image);
                var butler = new Butler
                {
                  
                  Name = butlerVM.Name,
                  Email = butlerVM.Email,
                  PhoneNumber = butlerVM.PhoneNumber,
                  status=butlerVM.status,
                  Profession=butlerVM.Profession,
                  skillSet = butlerVM.skillSet,
                  Address = butlerVM.Address,
                  Rating = butlerVM.Rating,
                  image = result.Url.ToString(),

                };
              //  _bookClubRepository.Add(bookClub);
              _context.SaveChanges();
                _context.Add(butler);
                return RedirectToAction("Index");

            }
            else
            {
                ModelState.AddModelError("", "Failed processing your photo");
                return View(butlerVM);

            }
           
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