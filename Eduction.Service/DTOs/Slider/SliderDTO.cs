using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Service.DTOs.Slider
{
    public class SliderDTO : BaseEntityDTO
    {
        public string Path { get; set; }
        public byte Status { get; set; }
    }
}
