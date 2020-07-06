using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Service.DTOs.Slider
{
    public class SliderItemDTO
    {
        public SliderItemDTO()
        {
            sliders = new List<Core.Domains.Slider>();
        }
       public List<Eduction.Core.Domains.Slider> sliders = new List<Core.Domains.Slider>();
    }
 
}
