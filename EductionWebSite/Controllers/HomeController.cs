using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EductionWeb.Models;
using Eduction.Service.Catalog.Home;
using Eduction.Service.DTOs.Index;

namespace EductionWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeService _homeService = null;

        public HomeController(IHomeService homeService)
        {
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            IndexDTO dTO = new IndexDTO();
            dTO= _homeService.OnceLook();
            return View(dTO);
        }
      
     
    }
   
}
