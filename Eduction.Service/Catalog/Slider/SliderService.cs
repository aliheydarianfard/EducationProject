using Eduction.Data.Repository;
using Eduction.Service.DTOs.Slider;
using Eduction.Service.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Eduction.Service.Catalog.Slider
{
    public class SliderService : ISliderService
    {
        private readonly IRepository<Eduction.Core.Domains.Slider> _sliderRepository = null;
        private readonly IHostingEnvironment _hosting;

        public SliderService(IRepository<Core.Domains.Slider> sliderRepository, IHostingEnvironment hosting)
        {
            _sliderRepository = sliderRepository;
            _hosting = hosting;
        }

        public async Task<SliderItemDTO> SearchAllSliderAsync()
        {
            SliderItemDTO dTO = new SliderItemDTO();
            dTO.sliders = await _sliderRepository.TableNoTracking.ToListAsync();
            return dTO;
        }
        public  IEnumerable<Core.Domains.Slider> SearchAllSliderforcomponnet()
        {
            
            return  _sliderRepository.Table;
        }
        public async Task<SliderDTO> RegsiterSliderPhoto(SliderDTO SldierDTO, IFormFile files)
        {
            string name = Guid.NewGuid().ToString();
            var path = Path.Combine(_hosting.WebRootPath, "img/banner/" + name + ".jpg");
            var patName = name + ".jpg";
            if (files.Length > 0)
            {
                using (var steam = new FileStream(path, FileMode.Create))
                {
                    await files.CopyToAsync(steam);
                }
            }
            SldierDTO.Path = patName;
            SldierDTO.Status = 1;
            var slider = SldierDTO.ToEntity<Eduction.Core.Domains.Slider>();
            await _sliderRepository.InsertAsync(slider);
            SldierDTO.ID = slider.ID;
            return SldierDTO;
        }
    }
}
