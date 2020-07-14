using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;


namespace EductionWeb.Areas.Admin
{
    [Area("Admin")]
    [Authorize]
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
    }
}
