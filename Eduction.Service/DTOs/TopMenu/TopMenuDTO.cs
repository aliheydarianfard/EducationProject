using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Service.DTOs.TopMenu
{
    public class TopMenu 
    {
        public TopMenu()
        {
            this.ListCategory = new List<TopMenuItemDTO>();

        }
        public List<TopMenuItemDTO> ListCategory { get; set; }
    }
    public class TopMenuItemDTO
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }
   
}
