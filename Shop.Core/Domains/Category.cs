using Eduction.Core.Domains.BaseDomains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Core.Domains
{
	public class Category : BaseEntity
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual ICollection<Course> Courses { get; set; }
	}
}
