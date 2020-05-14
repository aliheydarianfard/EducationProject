using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EductionWeb.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult GeneralError(int? statusCode)
        {
            return View(statusCode);
        }
       
    }
}