using Eduction.Core.Domains.BaseDomains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Core.Domains
{
   public class Slider: BaseEntity
    {
        public string Path { get; set; }
        public byte Status { get; set; }
    }
}
