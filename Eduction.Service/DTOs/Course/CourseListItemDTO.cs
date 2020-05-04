using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Service.DTOs.Course
{
   public class CourseListItemDTO
    {
		public CourseListItemDTO()
		{
			CourseItems = new List<Core.Domains.Course>();
			Categories = new List<SelectListItem>();
		}
        public string CourseSearchName { get; set; }
		public List<Core.Domains.Course> CourseItems { get; set; }
		public int CategoryID { get; set; }
		public  IList<SelectListItem> Categories { get; set; }

	}
	
}
