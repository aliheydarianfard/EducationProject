


using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Core.Domains
{
    public class Customer:IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NationalCode { get; set; }
    }
    public class CustomerRole : IdentityRole<int> 
    {

    }
}
