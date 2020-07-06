using Eduction.Service.DTOs.Slider;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eduction.Service.Catalog.Slider
{
    public interface ISliderService
    {
        Task<SliderDTO> RegsiterSliderPhoto(SliderDTO dTO, IFormFile files);
        Task<SliderItemDTO> SearchAllSliderAsync();
        IEnumerable<Core.Domains.Slider> SearchAllSliderforcomponnet();
    }
}