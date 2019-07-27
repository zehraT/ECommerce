using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;

namespace ECommerce.Controllers
{
    public class CatogoryController : Controller
    {
        [Route("/kategori/{id}")]
        public IActionResult Index(int id)
        {
            Catogory category = new Catogory();

            using (ECommerceContext eCommerceContext=new ECommerceContext())
            {
                category = eCommerceContext.Categories.SingleOrDefault(a=>a.Id==id);
            }

            ViewData["Title"] = category.Name;
            return View(category);
        }
    }
}