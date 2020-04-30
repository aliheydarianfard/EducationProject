using Eduction.Data.Repository;
using Eduction.Service.DTOs.Teacher;
using Eduction.Service.Extentions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduction.Service.Catalog.Teacher
{
    public class TeacherService : ITeacherService
    {
        private readonly IRepository<Eduction.Core.Domains.Teacher> _teacherRepository = null;

        public TeacherService(IRepository<Core.Domains.Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }
        public async Task<TeacherListItemDTO> SearchTeacheryAsync(string _TeacherSearchName)
        {
            TeacherListItemDTO dto = new TeacherListItemDTO();
            dto.TeacherSearchName = _TeacherSearchName;
            if (!string.IsNullOrEmpty(dto.TeacherSearchName))
                dto.Teachers = await _teacherRepository.TableNoTracking.Where(p => p.LastName.Contains(dto.TeacherSearchName)).ToListAsync();
            else
                dto.Teachers = await _teacherRepository.TableNoTracking.ToListAsync();
            return dto;

        }
        public async Task<Eduction.Core.Domains.Teacher> SearchTeacherByIdAsync(int? id)
        {
            var teacher = await _teacherRepository.GetByIdAsync(id);
            return teacher;
        }
        public async Task UpdateCategoryAsync(TeacherDTO teacherDTO)
        {
            var teacher = await _teacherRepository.GetByIdAsync(teacherDTO.ID);
            teacher.FirstName = teacherDTO.FirstName;
            teacher.LastName = teacherDTO.LastName;
            teacher.NationalCode = teacherDTO.NationalCode;
            teacher.LastDegreeOfEducation = teacherDTO.LastDegreeOfEducation;
            teacher.PhoneNumber = teacherDTO.PhoneNumber;
            teacher.Email = teacherDTO.Email;
            teacher.BirthDay = teacherDTO.BirthDay;
            teacher.Sex = teacherDTO.Sex;
            await _teacherRepository.UpdateAsync(teacher);
        }
        public async Task<TeacherDTO> RegisterTeacheryAsync(TeacherDTO teacherDTO)
        {
            var teacher = teacherDTO.ToEntity<Eduction.Core.Domains.Teacher>();
            await _teacherRepository.InsertAsync(teacher);
            teacherDTO.ID = teacher.ID;
            return teacherDTO;
        }
        public async Task RemoveTeacherAsync(int id)
        {
            var teacher = await _teacherRepository.GetByIdAsNoTrackingAsync(id);
            await _teacherRepository.DeleteAsync(teacher);
        }

    }
}
