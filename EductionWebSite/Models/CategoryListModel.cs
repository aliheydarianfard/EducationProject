using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduction.Core.Domains;
namespace EductionWeb.Models
{
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
