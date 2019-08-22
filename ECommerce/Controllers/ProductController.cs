using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        [Route("/urun/{id}")]
        public IActionResult Index(int id)
        {
            Models.Product product;

            using (ECommerceContext eCommerceContext = new ECommerceContext())
            {
                product = eCommerceContext.Products.SingleOrDefault(a => a.Id == id);
            }

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            //burada ürünün kategorsini de değiştirebilmek için yeni bir class oluşturup içerisine kategorileri göndereceğiz
            Models.ProductEditViewModel model;
            using (ECommerceContext context = new ECommerceContext())
            {
                model = new Models.ProductEditViewModel
                {
                    Product = context.Products.SingleOrDefault(x => x.Id == id),
                    Categories = context.Categories.ToList()
                };
            }
            return View(model);
        }

        //Get işlemleri için cevap vermez sadece post işlemleri çalışır
        [HttpPost]
        public IActionResult Edit(Models.Product product)
        {
            using (ECommerceContext context = new ECommerceContext())
            {
                Models.Product updatedProduct = context.Products.SingleOrDefault(x => x.Id == product.Id);
                if (updatedProduct != null)
                {
                    updatedProduct.Name = product.Name;
                    updatedProduct.Description = product.Description;
                    updatedProduct.CategoryId = product.CategoryId;

                    context.Products.Update(updatedProduct);
                    context.SaveChanges();
                }
            }
            //tekrar index metoduna yönlendiriyor
            return RedirectToAction("Index", new { id = product.Id });
        }
    }
}