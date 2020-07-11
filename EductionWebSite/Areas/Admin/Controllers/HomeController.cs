using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EductionWeb.Areas.Admin.Models;
using Eduction.Service.Catalog.Home;
using Eduction.Service.DTOs.Index;
using Microsoft.AspNetCore.Authorization;

namespace EductionWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
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
