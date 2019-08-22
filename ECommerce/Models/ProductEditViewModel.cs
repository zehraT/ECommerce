using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Models
{
    public class ProductEditViewModel
    {
        public List<Category> Categories { get; internal set; }
        public Product Product { get; internal set; }
    }
}
