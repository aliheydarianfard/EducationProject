using Eduction.Core.Domains.BaseDomains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Core.Domains
{
	public class Teacher:BaseEntity
	{
	
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FullName
		{
			get => FirstName + " " + LastName;
		}
		public DateTime BirthDay { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public int NationalCode { get; set; }
		public string LastDegreeOfEducation { get; set; }
		public short Sex { get; set; }
		public virtual ICollection<Course> Courses { get; set; }
	
	}
}
