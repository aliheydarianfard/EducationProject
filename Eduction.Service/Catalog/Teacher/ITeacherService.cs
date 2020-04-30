using Eduction.Service.DTOs.Teacher;
using System.Threading.Tasks;

namespace Eduction.Service.Catalog.Teacher
{
    public interface ITeacherService
    {
        Task<TeacherDTO> RegisterTeacheryAsync(TeacherDTO teacherDTO);
        Task RemoveTeacherAsync(int id);
        Task<Core.Domains.Teacher> SearchTeacherByIdAsync(int? id);
        Task<TeacherListItemDTO> SearchTeacheryAsync(string _TeacherSearchName);
        Task UpdateCategoryAsync(TeacherDTO teacherDTO);
    }
}