using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Service.DTOs
{
	public interface IDateDTO
	{
		DateTime CreateOn { get; set; }

		DateTime UpdateOn { get; set; }
		string LocalCreateOn { get; set; }

		string LocalUpdateOn { get; set; }
	}
}
