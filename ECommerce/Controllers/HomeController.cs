using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// test
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            using (ECommerceContext eCommerceContext=new ECommerceContext())
            {
                List<User> users = eCommerceContext.Users.Include(a=>a.Addresses).ToList();
                List<Address> addresses=eCommerceContext.Addresses.Include(a=>a.User).ToList();


            }
            return View();
        }

       

    }
}
