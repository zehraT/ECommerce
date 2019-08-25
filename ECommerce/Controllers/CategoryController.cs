
using ECommerce.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ECommerce.Controllers
{
    public class CategoryController : Controller
    {
        [Route("/kategori/{id}")]
        public IActionResult Index(int id)
        {
            Category category = new Category();

            using (ECommerce.Data.ECommerceContext eCommerceContext = new ECommerce.Data.ECommerceContext())
            {
                category = eCommerceContext.Categories.SingleOrDefault(a => a.Id == id);
            }

            ViewData["Title"] = category.Name;

            return View(category);
        }
    }
}