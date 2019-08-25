using System.Linq;
using ECommerce.Data.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route("/urun/{id}")]
        public IActionResult Index(int id)
        {

            Data.Models.Product product = _productRepository.Find(id);

            //Data.Models.Product product;

            //using (ECommerce.Data.ECommerceContext eCommerceContext = new ECommerce.Data.ECommerceContext())
            //{
            //    product = eCommerceContext.Products.SingleOrDefault(a => a.Id == id);
            //}

            return View(product);
        }

        public IActionResult Edit(int id)
        {
            //burada ürünün kategorsini de değiştirebilmek için yeni bir class oluşturup içerisine kategorileri göndereceğiz
            Data.Models.ProductEditViewModel model;
            using (ECommerce.Data.ECommerceContext context = new ECommerce.Data.ECommerceContext())
            {
                model = new Data.Models.ProductEditViewModel
                {
                    //Product = context.Products.SingleOrDefault(x => x.Id == id),
                    //Categories = context.Categories.ToList()
                };
            }
            return View(model);
        }

        //Get işlemleri için cevap vermez sadece post işlemleri çalışır
        [HttpPost]
        public IActionResult Edit(Data.Models.Product product)
        {
            using (ECommerce.Data.ECommerceContext context = new ECommerce.Data.ECommerceContext())
            {
                Data.Models.Product updatedProduct = context.Products.SingleOrDefault(x => x.Id == product.Id);
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