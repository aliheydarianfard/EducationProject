using Eduction.Service.DTOs.Teacher;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eduction.Service.Catalog.Teacher
{
    public interface ITeacherService
    {
        Task<TeacherDTO> RegisterTeacheryAsync(TeacherDTO teacherDTO);
        Task RemoveTeacherAsync(int id);
        IEnumerable<Core.Domains.Teacher> SearchAllTeacher();
        Task<TeacherDTO> SearchTeacherByIdAsync(int? id);
        Task<TeacherListItemDTO> SearchTeacheryAsync(string _TeacherSearchName);
        Task UpdateCategoryAsync(TeacherDTO teacherDTO);
    }
}