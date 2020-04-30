using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Core.Domains.BaseDomains
{
	public abstract class BaseEntity : Entity, IDateEntity
	{
		public BaseEntity()
		{
			UpdateOn = DateTime.Now;
		}
		public int ID { get; set; }
		public DateTime CreateOn { get; set; }
		public DateTime UpdateOn { get; set; }
	}
}
