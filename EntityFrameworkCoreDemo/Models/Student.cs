using System;
using System.Collections.Generic;

#nullable disable

namespace EFCore_DataBaseFirst_Demo.Models
{
    public partial class Student
    {
        public long StudentId { get; set; }
        public string StudentName { get; set; }
        public long StudentRollNo { get; set; }
        public string StudentDivision { get; set; }
        public long TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public Student()
        {}

        public Student(string studentName, long studentRollNo, string studentDivision, long teacherId)
        {
            StudentName = studentName;
            StudentRollNo = studentRollNo;
            StudentDivision = studentDivision;
            TeacherId = teacherId;
        }
    }
}
