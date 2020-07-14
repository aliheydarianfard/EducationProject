using Eduction.Core.Domains.BaseDomains;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Core.Domains
{
    public class Topic : BaseEntity
    {
        public string Title { get; set; }
        public virtual int CourseID { get; set; }
        public virtual Course Course { get; set; }
    }
}
