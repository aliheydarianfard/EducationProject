using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor;
namespace Eduction.Service.DTOs.Course
{
	public class CourseDTO:BaseEntityDTO
    {
		public CourseDTO()
		{
			Categories = new List<SelectListItem>();
			Teachers = new List<SelectListItem>();
		}
		[Required(ErrorMessage ="لطفا نام دوره را وارد کنید")]
		public string Name { get; set; }
		[Required(ErrorMessage ="لطفا نام انگلیسی دوره را وارد کنید")]
		public string EnglishName { get; set; }
		public string Code { get; set; }
		[Required(ErrorMessage ="نام منتشر کننده را وارد کنید")]
		public string PublisherName { get; set; }
		public string Description { get; set; }
		public string Languge { get; set; }
		public string TypeCourse { get; set; }
		[Required(ErrorMessage ="لطفا زمان را وارد کنید")]
		public string Time { get; set; }
		[Required(ErrorMessage ="لطفا هزینه را وارد کنید")]
		public int Cost { get; set; }

		//[Required(ErrorMessage = "لطفا پوستر را وارد کنید")]
		public string Path { get; set; }
		public  int CategoryID { get; set; }
		public  int TeacherID { get; set; }
		public IList<SelectListItem> Categories { get; set; }
		public IList<SelectListItem> Teachers { get; set; }

	}
}
