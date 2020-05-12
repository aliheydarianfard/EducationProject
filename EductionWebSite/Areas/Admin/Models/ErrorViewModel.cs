using Microsoft.AspNetCore.Mvc;
using System;

namespace EductionWeb.Areas.Admin.Models
{
	[Area("Admin")]
	public class ErrorViewModel
	{
		public string RequestId { get; set; }

		public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
	}
}