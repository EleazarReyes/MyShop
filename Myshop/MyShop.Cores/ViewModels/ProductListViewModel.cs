using MyShop.Cores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Cores.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Product { get; set; }
        public IEnumerable<ProductCategory> productCategories { get; set; }
    }
}
