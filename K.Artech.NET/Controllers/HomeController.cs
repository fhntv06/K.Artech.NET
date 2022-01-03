using K.Artech.NET.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace K.Artech.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // создание контекста данных
        BookContext db = new BookContext();
        public IActionResult Index()
        {
            var books = db.Books;

            // графический объект ViewBag - динамический объект в котором можно определить любые переменные и вложить в них любое содержимое
            ViewBag.Boooks = books;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int Id)
        {
            ViewBag.BookId = Id;

            return View();

        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            // добавление информации о покупке в базу данных
            db.Purchases.Add(purchase);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Заказ принят: " + purchase.Date + 
            '\n' + "Спасибо, " + purchase.Person + ", за покупку!" + 
            '\n' + "Книга будет доставлена в " + purchase.Address + ".";
        }
    }
}