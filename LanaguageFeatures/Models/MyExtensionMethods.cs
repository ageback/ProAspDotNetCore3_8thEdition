using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanaguageFeatures.Models
{
    public static class MyExtensionMethods
    {
        public static decimal TotalPrice(this IEnumerable<Product> products)
        {
            decimal total = 0;
            foreach(Product prod in products)
            {
                total += prod?.Price ?? 0;
            }
            return total;
        }

        public static IEnumerable<Product> FilterPrice(this IEnumerable<Product> productEnum, decimal minimumPirce)
        {
            foreach(Product prod in productEnum)
            {
                if ((prod?.Price ?? 0) >= minimumPirce)
                {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> FilterByName(this IEnumerable<Product> productEnum, char firstLetter)
        {
            foreach(Product prod in productEnum)
            {
                if (prod?.Name?[0] == firstLetter)
                {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product> Filter(this IEnumerable<Product> productEnum, Func<Product, bool> selector)
        {
            foreach(Product prod in productEnum)
            {
                if(selector(prod))
                {
                    yield return prod;
                }
            }
        }
    }
}
