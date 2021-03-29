using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore_DataBaseFirst_Demo.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            Students = new HashSet<Student>();
        }

        public long TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string SubjectExpertise { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
