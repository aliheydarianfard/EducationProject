using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduction.Service.Catalog.Slider;
using Eduction.Service.DTOs.Slider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EductionWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : AdminController
    {
        private readonly ISliderService _sliderService = null;

        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public async Task<IActionResult> List()
        {
            return View(await _sliderService.SearchAllSliderAsync());
        }
        [HttpGet]
        public async Task<IActionResult> Create() 
        {
            SliderDTO dTO = new SliderDTO();
            return View(dTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderDTO dTO,IFormFile files)
        {
            await _sliderService.RegsiterSliderPhoto(dTO, files);
            return RedirectToAction("List");
        }
    }
}