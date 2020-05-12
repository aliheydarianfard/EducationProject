using Eduction.Service.DTOs.Course;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eduction.Service.Catalog.Course
{
    public interface ICourseService
    {
        Task<CourseDTO> RegisterCourseAsync(CourseDTO courseDTO, IFormFile files);
        Task RemoveCourseAsync(int id);
        Task<CourseListItemDTO> SearchCourseAsync( CourseListItemDTO dTO);
        Task<Core.Domains.Course> SearchCourseByIdAsync(int? id);
        Task UpdatecourseAsync(CourseDTO courseDTO);
    }
}