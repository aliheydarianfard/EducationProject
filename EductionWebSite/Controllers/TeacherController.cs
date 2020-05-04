using Eduction.Core.Extension;
using Eduction.Service.Catalog.Teacher;
using Eduction.Service.DTOs.Teacher;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EductionWeb.Controllers
{
    public class TeacherController: Controller
    {
        private readonly ITeacherService _teacherService = null;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public  IActionResult Index() 
        {
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> List(TeacherListItemDTO dTO) 
        {

            return View(await _teacherService.SearchTeacheryAsync(dTO.TeacherSearchName)); 
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            TeacherDTO dTO = new TeacherDTO();
         
            var teacher =await _teacherService.SearchTeacherByIdAsync(id);
            if (teacher != null)
            {
                dTO.FirstName = teacher.FirstName;
                dTO.LastName = teacher.LastName;
                dTO.NationalCode = teacher.NationalCode;
                dTO.LastDegreeOfEducation = teacher.LastDegreeOfEducation;
                dTO.PhoneNumber = teacher.PhoneNumber;
                dTO.Email = teacher.Email;
                dTO.BirthDay = teacher.BirthDay;
                dTO.Sex = teacher.Sex;
            }
            return View (dTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeacherDTO dTO)
        {
            dTO.Sex = 1;
           
            if (!ModelState.IsValid)
                return View(dTO);
            if (dTO.ID != 0)
                await _teacherService.UpdateCategoryAsync(dTO);
            else
                await _teacherService.RegisterTeacheryAsync(dTO);
            return RedirectToAction("List");


        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            await _teacherService.RemoveTeacherAsync(id);
            return RedirectToAction("List");
        }
    }
}
