using AFNews.Data;
using AFNews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AFNews.Controllers
{
    public class HomeController : Controller
    {

        NewsDbContext db;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, NewsDbContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult Index()
        {
            var categories = db.Categories.ToList();
            return View(categories);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveContact(ContactUs contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Messages()
        {
            return View(db.Contacts.ToList());
        }

        public IActionResult News(int id)
        {
            var news = db.News.Where(x => x.categoryId == id).ToList();

            return View(news);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}