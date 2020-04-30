using Eduction.FrameWork.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eduction.Service.DTOs.Category
{
	public class CategoryDTO:BaseEntityDTO
	{
		[Display(Name="نام دسته")]
		[Required(ErrorMessage ="لطفا نام را وارد نمایید")]
		[MyCustomValidation]
		public string Name { get; set; }
		[Display(Name="توضیحات دسته")]
		public string Description { get; set; }
	}
}
