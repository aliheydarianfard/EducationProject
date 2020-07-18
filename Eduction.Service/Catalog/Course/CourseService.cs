using Eduction.Data.Repository;
using Eduction.Service.Catalog.Category;
using Eduction.Service.DTOs.Course;
using Eduction.Service.Extentions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduction.Service.Catalog.Course
{
    public class CourseService : ICourseService
    {
        #region Dependency
        private readonly IRepository<Eduction.Core.Domains.Course> _courseRepository = null;
        private readonly IRepository<Eduction.Core.Domains.Category> _categoryRepository = null;
        private readonly IRepository<Eduction.Core.Domains.Teacher> _teacherRepository = null;
        private readonly ICategoryService _categoryService = null;
        private readonly IHostingEnvironment _hosting;

        public CourseService(IRepository<Core.Domains.Course> courseRepository, IRepository<Core.Domains.Category> categoryRepository, IRepository<Core.Domains.Teacher> teacherRepository, ICategoryService categoryService, IHostingEnvironment hosting)
        {
            _courseRepository = courseRepository;
            _categoryRepository = categoryRepository;
            _teacherRepository = teacherRepository;
            _categoryService = categoryService;
            _hosting = hosting;
        }


        #endregion
        public async Task<CourseListItemDTO> SearchCourseAsync(CourseListItemDTO dto)
        {
            PaperingInfoForCategoryFilter(dto);
            dto.CourseSearchName = dto.CourseSearchName;
            if (!string.IsNullOrEmpty(dto.CourseSearchName))
                dto.CourseItems = await _courseRepository.TableNoTracking.Where(p => p.Name.Contains(dto.CourseSearchName) || p.EnglishName.Contains(dto.CourseSearchName)).Include(p => p.Category).Include(p => p.Teacher).OrderByDescending(o => o.ID).ToListAsync();
            else if (dto.CategoryID != 0)
                dto.CourseItems = await _courseRepository.TableNoTracking.Where(p => p.CategoryID == dto.CategoryID).Include(p => p.Category).Include(p => p.Teacher).OrderByDescending(o => o.ID).ToListAsync();
            
            else
                dto.CourseItems = await _courseRepository.TableNoTracking.Include(p => p.Category).Include(p => p.Teacher).OrderByDescending(o=> o.ID ).ToListAsync();
            return dto;

        }
        public async Task<Eduction.Core.Domains.Course> SearchCourseByIdAsync(int? id)
        {
            var category = await _courseRepository.GetByIdAsync(id);
            return category;

        }
        public async Task<CourseDTO> RegisterCourseAsync(CourseDTO courseDTO, IFormFile files)
        {
            
            string name = Guid.NewGuid().ToString();
            var path = Path.Combine(_hosting.WebRootPath, "Pictures/Course/" + name + ".jpg");
            var patName = name + ".jpg";
            if (files.Length > 0)
            {
                using (var steam = new FileStream(path, FileMode.Create))
                {
                    await files.CopyToAsync(steam);
                }
            }
            var course = courseDTO.ToEntity<Eduction.Core.Domains.Course>();
            string englishname = courseDTO.EnglishName;
            string CodeResult = englishname.Substring(0, 2)  +"-"+courseDTO.ID + courseDTO.TeacherID + courseDTO.CategoryID;
            course.Code = CodeResult;
            course.CategoryID = courseDTO.CategoryID;
            course.TeacherID = courseDTO.TeacherID;
            course.Path = patName;
            await _courseRepository.InsertAsync(course);
            courseDTO.ID = course.ID;
            return courseDTO;
        }
        public async Task UpdatecourseAsync(CourseDTO DTO)
        {
            var course = await _courseRepository.GetByIdAsync(DTO.ID);
            course.Name = DTO.Name;
            course.PublisherName = DTO.PublisherName;
            course.Languge = DTO.Languge;
            course.Time = DTO.Time;
            course.EnglishName = DTO.EnglishName;
            course.Description = DTO.Description;
            course.Cost = Convert.ToInt32(DTO.Cost);
            course.CategoryID = DTO.CategoryID;
            course.TeacherID = DTO.TeacherID;
            course.TypeCourse = DTO.TypeCourse;
            course.UpdateOn = DateTime.Now;
            await _courseRepository.UpdateAsync(course);
        }
        public async Task RemoveCourseAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            await _courseRepository.DeleteAsync(course);
        }
        public void PaperingInfoForCategoryFilter(CourseListItemDTO dTO)
        {
            var teachers = _categoryService.SearchAllCategoryAsync();
            dTO.Categories.Add(new SelectListItem()
            {
                Text = " تمامی دسته ها",
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
