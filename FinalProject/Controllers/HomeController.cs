using FinalProject.Data;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment environment;

        public HomeController(ApplicationDbContext dbContext, IWebHostEnvironment environment)
        {
            _dbContext = dbContext;
            this.environment = environment;
        }

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        // GET: Product/Search
        public IActionResult Search()
        {
            return View();
        }

        // POST: Product/Search
        [HttpPost]
        public IActionResult Search(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                TempData["ErrorMessage"] = "Please enter a search term.";
                return RedirectToAction("Index");
            }

            var products = _dbContext.products
                                     .Where(p => p.Name.Contains(searchTerm))
                                     .ToList();

            if (products == null || products.Count == 0)
            {
                TempData["ErrorMessage"] = "No products found.";
                return RedirectToAction("Index");
            }

            return View("Search", products);
        }


        public IActionResult Index()
        {
            var products = _dbContext.products.ToList();
            return View(products);
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