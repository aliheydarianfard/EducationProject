using Eduction.Service.Catalog.Category;
using Eduction.Service.Catalog.Course;
using Eduction.Service.DTOs.Course;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Eduction.Service.Catalog.Teacher;
using Eduction.Service.DTOs.Teacher;

namespace EductionWeb.Controllers
{
    public class CourseController : Controller
    {
        #region Dependance
        private readonly ICourseService _courseService = null;
        private readonly ICategoryService _categoryService = null;
        private readonly ITeacherService _teacherService = null;

        public CourseController(ICourseService courseService, ICategoryService categoryService, ITeacherService teacherService)
        {
            _courseService = courseService;
            _categoryService = categoryService;
            _teacherService = teacherService;
        }
        #endregion
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }
        public async Task<IActionResult> List(CourseListItemDTO dto)

        {
            return View(await _courseService.SearchCourseAsync(dto));
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? id)
        {
            CourseDTO dTO = new CourseDTO();
            PaperingInfoForSelectTag(dTO);
            var Course = await _courseService.SearchCourseByIdAsync(id);
            if (Course != null)
            {
                dTO.Name = Course.Name;
                dTO.PublisherName = Course.PublisherName;
                dTO.Time = Course.Time;
                dTO.Code = Course.Code;
                dTO.Cost = Course.Cost;
                dTO.EnglishName = Course.EnglishName;
                dTO.Description = Course.Description;
                dTO.Languge = Course.Languge;
                dTO.TypeCourse = Course.TypeCourse;
                dTO.CategoryID = Course.Category.ID;
                dTO.TeacherID = Course.Teacher.ID;
            }
            return View(dTO);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            CourseDTO dTO = new CourseDTO();
            PaperingInfoForSelectTag(dTO);
            var Course = await _courseService.SearchCourseByIdAsync(id);
            if (Course != null)
            {
                dTO.Name = Course.Name;
                dTO.PublisherName = Course.PublisherName;
                dTO.Time = Course.Time;
                dTO.Code = Course.Code;
                dTO.Cost = Course.Cost;
                dTO.EnglishName = Course.EnglishName;
                dTO.Description = Course.Description;
                dTO.Languge = Course.Languge;
                dTO.TypeCourse = Course.TypeCourse;
                dTO.CategoryID = Course.Category.ID;
                dTO.TeacherID = Course.Teacher.ID;
            }
            return View(dTO);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseDTO dTO)
        {
            if (!ModelState.IsValid)
                return View(dTO);
            if (dTO.ID != 0)
                await _courseService.UpdatecourseAsync(dTO);
            else
                await _courseService.RegisterCourseAsync(dTO);
            return RedirectToAction("List");

        }
        [HttpGet]
        public async Task<IActionResult> Remove(int id)
        {
            await _courseService.RemoveCourseAsync(id);
            return RedirectToAction("List");

        }
        public void PaperingInfoForSelectTag(CourseDTO dTO)
        {
            var categories = _categoryService.SearchAllCategoryAsync();
            var teachers = _teacherService.SearchAllTeacher();
            foreach (var item in categories)
            {
                dTO.Categories.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.ID.ToString()
                });
            }
            foreach (var item in teachers)
            {
                dTO.Teachers.Add(new SelectListItem()
                {
                    Text = item.FullName,
                    Value = item.ID.ToString()

                });
            }
        }
        public void PaperingInfoForCategoryFilter(CourseListItemDTO dTO)
        {
            var teachers = _categoryService.SearchAllCategoryAsync();
            dTO.Categories.Add(new SelectListItem()
            {
                Text =" تمامی دسته ها",
                Value = "0"

            });

            foreach (var item in teachers)
            {
                dTO.Categories.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.ID.ToString()

                });
            }
        }
    }
}

