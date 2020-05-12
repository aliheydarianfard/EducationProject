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
        private readonly IHostingEnvironment _hosting;

        public HomeController(IHostingEnvironment hosting)
        {
            this._hosting = hosting;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SavePicAsync(IFormFile files)
        {
            if (!files.ContentType.Contains("image"))
                return new StatusCodeResult(403);
            string name = Guid.NewGuid().ToString();
            var path = Path.Combine(_hosting.WebRootPath, "Pictures/Course" + name + ".jpg");
            if (files.Length > 0)
            {
                using (var steam = new FileStream(path, FileMode.Create))
                {
                   await files.CopyToAsync(steam);
                }
            }
            return Ok();
        }
    }
}