﻿using LanaguageFeatures.Models;
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
                results.Add(string.Format($"Name: {name}, Price: {price}, Related: {relatedName}");
            }
            return View(results);
        }
    }
}
