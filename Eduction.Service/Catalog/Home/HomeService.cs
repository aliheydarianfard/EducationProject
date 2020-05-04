using Eduction.Core.Domains;
using Eduction.Data.Repository;
using Eduction.Service.DTOs.Index;
using Eduction.Service.DTOs.Teacher;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eduction.Service.Catalog.Home
{
    public class HomeService : IHomeService
    {
        private readonly IRepository<Eduction.Core.Domains.Teacher> _teacherRepository = null;
        private readonly IRepository<Eduction.Core.Domains.Category> _categoryRepository = null;
        private readonly IRepository<Eduction.Core.Domains.Course> _courseRepository = null;

        public HomeService(IRepository<Core.Domains.Teacher> teacherRepository, IRepository<Core.Domains.Category> categoryRepository, IRepository<Core.Domains.Course> courseRepository)
        {
            _teacherRepository = teacherRepository;
            _categoryRepository = categoryRepository;
            _courseRepository = courseRepository;
        }

        public  IndexDTO OnceLook( )
        {
            IndexDTO dTO = new IndexDTO();
            dTO.TeacherCount = _teacherRepository.TableNoTracking.ToList().Count;
            dTO.CategoryCount = _categoryRepository.TableNoTracking.ToList().Count;
            dTO.CourseCount = _courseRepository.TableNoTracking.ToList().Count;
            return dTO;
        }

       
    }
}
