using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Eduction.Service.DTOs.Teacher
{
    public class TeacherDTO:BaseEntityDTO
    {
		[Required (ErrorMessage ="نام را وارد کنید")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "نام خانوادگی را وارد کنید")]
		public string LastName { get; set; }
		public DateTime BirthDay { get; set; }
		[EmailAddress(ErrorMessage = "فرما پست الکترونیک را رعایت فرمایید")]
		[Required(ErrorMessage ="پست الکترونیک را وارد کنید")]
		public string Email { get; set; }
		[Phone(ErrorMessage ="فرمت تلفن را رعاییت فرمایید")]
		[Required(ErrorMessage ="تلفن را وارد نمایید")]
		public string PhoneNumber { get; set; }
		[Required(ErrorMessage ="کد ملی را وارد کنید")]
		public string NationalCode { get; set; }
		[Required(ErrorMessage ="آخرین مدرک را وارد کنید")]
		public string LastDegreeOfEducation { get; set; }
		public short Sex { get; set; }
	}
}
