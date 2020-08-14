using LanaguageFeatures.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanaguageFeatures.Controllers
{
    public class HomeController :Controller
    {
        public ViewResult Index()
        {
            List<string> results = new List<string>();
            foreach(Product p in Product.GetProducts())
            {
                
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                results.Add(string.Format($"Name: {name}, Price: {price}, Related: {relatedName}"));
            }
            return View(results);
        }

        /// <summary>
        /// 扩展方法
        /// </summary>
        /// <returns></returns>
        public ViewResult ExtMethod()
        {
            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

            Product[] prodArray =
            {
                new Product{Name="Kayak",Price=275M },
                new Product{Name="Lifejacket",Price=48.95M },
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            //decimal cartTotal = cart.TotalPrice();
            decimal arrayTotal = prodArray.FilterPrice(20).TotalPrice();
            //return View("Index", new string[] { $"Total: {cartTotal:C2}" });
            return View("Index", new string[] { $"Array Total: {arrayTotal:C2}" });

        }

        public ViewResult Filter()
        {
            //ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

            Product[] prodArray =
            {
                new Product{Name="Kayak",Price=275M },
                new Product{Name="Lifejacket",Price=48.95M },
                new Product {Name = "Soccer ball", Price = 19.50M},
                new Product {Name = "Corner flag", Price = 34.95M}
            };

            //decimal cartTotal = cart.TotalPrice();
            decimal priceFilterTotal = prodArray.FilterPrice(20).TotalPrice();
            decimal nameFilterTotal = prodArray.FilterByName('S').TotalPrice();
            //return View("Index", new string[] { $"Total: {cartTotal:C2}" });
            return View("Index", new string[] { $"Array Total: {priceFilterTotal:C2}",$"Name Total: {nameFilterTotal:C2}" });

        }

        public async Task<ViewResult> AsyncMethod()
        {
            long? length = await MyAsyncMethods.GetPageLength2();
            return View("Index", new string[] { $"Length: {length}" });
        }
    }
}
