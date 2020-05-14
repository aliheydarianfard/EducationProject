using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EductionWeb.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
         
            return View();
        }       
    }
}