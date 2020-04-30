using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Service.DTOs.Category
{
	public class CategoryListItemDTO
	{
		public CategoryListItemDTO()
		{
			categories = new List<Eduction.Core.Domains.Category>();
		}
		public string CategorySearchName { get; set; }
		public List< Eduction.Core.Domains.Category> categories { get; set; }
	}
}
