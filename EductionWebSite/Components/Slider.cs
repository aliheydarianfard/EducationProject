using Eduction.Service.Catalog.Category;
using Eduction.Service.Catalog.Slider;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EductionWeb.Components
{
    public class SliderViewComponent:ViewComponent
    {
        private readonly ISliderService _sliderService = null;

        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IViewComponentResult Invoke() 
        {
            var _list = _sliderService.SearchAllSliderforcomponnet();
            var model = new Eduction.Service.DTOs.Slider.SliderItemDTO();
            foreach (var item in _list)
            {
                model.sliders.Add(new Eduction.Core.Domains.Slider
                {
                    Path=item.Path,
                    ID=item.ID,
                    Status=item.Status

                });
            }
            return View(model);
        }
    }
}
