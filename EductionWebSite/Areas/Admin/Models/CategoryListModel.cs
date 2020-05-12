using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduction.Core.Domains;
using Microsoft.AspNetCore.Mvc;

namespace EductionWeb.Areas.Admin.Models
{
	[Area("Admin")]
	public class CategoryListModel
	{
		public CategoryListModel()
		{
			Categories = new List<Category>();
		}
		public DateTime  a { get; set; }
		public string CategorySearchName { get; set; }
		public List<Category> Categories { get; set; }
	}
}
