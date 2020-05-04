using System;
using System.Collections.Generic;
using System.Text;

namespace Eduction.Service.DTOs.Teacher
{
    public class TeacherListItemDTO
    {
        public TeacherListItemDTO()
        {
            Teachers = new List<Core.Domains.Teacher>();
        }
        public string TeacherSearchName { get; set; }
        public int TeacherCount { get; set; }
        public List<Eduction.Core.Domains.Teacher> Teachers { get; set; }
    }
}
