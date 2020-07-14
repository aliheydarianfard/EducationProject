using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduction.Core.Domains;
using Eduction.Data;
using Eduction.Service.DTOs.Customer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EductionWeb.Areas.Admin.Controllers
{
    public class CustomerController : AdminController
    {
        #region Fileds
        private readonly UserManager<Customer> userManager;
        private readonly RoleManager<CustomerRole> roleManager;
        private readonly SqlServerApplicationContext context;

        public CustomerController(UserManager<Customer> userManager, RoleManager<CustomerRole> roleManager, SqlServerApplicationContext context)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
        }

        #endregion

        public IActionResult Index()
        {
            return Redirect("/Admin/Customer/List");
        }
        [HttpGet]
        public IActionResult List()
        {
            var users = userManager.Users.ToList();
            List<CustomerRegisterDTO> model = new List<CustomerRegisterDTO>();
            foreach (var item in users)
            {
                model.Add(new CustomerRegisterDTO()
                {
                    Email = item.Email,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Id = item.Id,
                    UserName = item.UserName
                });
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> ManageRoles(int id)
        {
            var user = await userManager.FindByIdAsync(id.ToString());

            var model = new ManageCustomeRoleModel();

            model.fullName = user.FirstName + " " + user.LastName;
            model.Id = user.Id.ToString();

            model.ListRoles = roleManager.Roles.ToList();

            foreach (var item in model.ListRoles)
            {
                if (await userManager.IsInRoleAsync(user, item.Name))
                {
                    model.AssignedRoles.Add(item);

                }
            }

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> SaveRole(string roleids, string userid)
        {
            if (roleids == null)
                return Ok();

            var listids = roleids.Split(";");
            var user = await userManager.FindByIdAsync(userid.ToString());
            var ListRoles = roleManager.Roles.ToList();
            foreach (var item in ListRoles)
            {

                if (listids.Contains(item.Id.ToString()))
                    await userManager.AddToRoleAsync(user, item.Name);
                else
                {

                    await userManager.RemoveFromRoleAsync(user, item.Name);
                }

            }
            return Ok();
        }
    }
}