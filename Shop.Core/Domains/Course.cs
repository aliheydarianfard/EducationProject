using Eduction.Core.Domains.BaseDomains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Core.Domains
{
	public class Course:BaseEntity
	{
		
		public string Name { get; set; }
		public string EnglishName { get; set; }
		public string Code { get; set; }
		public string PublisherName { get; set; }
		public string Description { get; set; }
		public string Languge { get; set; }
		public string TypeCourse { get; set; }
		public string Time { get; set; }
		public int Cost { get; set; }
		public virtual int CategoryID { get; set; }
		public virtual int TeacherID { get; set; }
		public virtual Category Category { get; set; }
		public virtual Teacher Teacher { get; set; }
	
	}
}
