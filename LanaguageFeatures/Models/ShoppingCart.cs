using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanaguageFeatures.Models
{
    public class ShoppingCart:IProductSelection
    {
        private List<Product> products = new List<Product>();

        public ShoppingCart(params Product[] prods)
        {
            products.AddRange(prods);
        }

        public IEnumerable<Product> Products { get => products; }
    }
}
