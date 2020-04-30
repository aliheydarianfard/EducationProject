using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Core.Domains.BaseDomains
{
	public interface IDateEntity
	{
		DateTime CreateOn { get; set; }
		DateTime UpdateOn { get; set; }
	}
}
