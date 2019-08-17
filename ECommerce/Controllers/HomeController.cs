using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "HOŞGELDİNİZ!";
            return View();
        }

        public IActionResult Help()
        {
            ViewData["Title"] = "Yardım Masası!";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "İletişim!";
            return View();
        }
    }
}