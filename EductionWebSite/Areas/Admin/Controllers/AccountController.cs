using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eduction.Core.Domains;
using Eduction.Service.DTOs.Customer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EductionWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<Customer> userManager;
        private readonly RoleManager<CustomerRole> roleManager;
        private readonly SignInManager<Customer> signInManager;

        public AccountController(UserManager<Customer> userManager, RoleManager<CustomerRole> roleManager
          , SignInManager<Customer> signInManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.signInManager = signInManager;
        }


        [HttpGet]
        public IActionResult Register()
        {
            CustomerRegisterDTO dto = new CustomerRegisterDTO();
            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(CustomerRegisterDTO model)
        {

            Customer customer = new Customer();
            customer.Email = model.Email;
            customer.FirstName = model.FirstName;
            customer.LastName = model.LastName;
            customer.PasswordHash = model.Password;
            customer.UserName = model.UserName;

            var result = await userManager.CreateAsync(customer, model.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(customer, isPersistent: false);
                return LocalRedirect("~/");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult LogIn()
        {
            var model = new CustomerLoginDTO();
            return View(model);
        }
   
        [HttpPost]
        public async Task<IActionResult> LogIn(CustomerLoginDTO model)
        {
            var returnUrl = model.returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.UserName,
                    model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {

                    return LocalRedirect(returnUrl);
                }
                if (result.IsLockedOut)
                {
                    return LocalRedirect("~/Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "کلمه کاربری یا رمز عبور اشتباست");
                    return View(model);
                }
            }
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            await signInManager.SignOutAsync();
            return LocalRedirect(returnUrl);
        }




        [AcceptVerbs("Get", "Post")]
        public async Task<IActionResult> CheckUserName(string UserName)
        {
            var isuser = await userManager.FindByNameAsync(UserName) == null;
            return Json(data: isuser);
        }

    }
}