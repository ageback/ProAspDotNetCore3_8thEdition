using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstProject.Models;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            string viewModel = hour < 12 ? "早上好" : "下午好";
            return View("MyView", viewModel);
        }
    }
}
