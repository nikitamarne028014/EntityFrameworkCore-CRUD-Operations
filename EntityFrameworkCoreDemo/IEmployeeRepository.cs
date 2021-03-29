
using EFCore_DataBaseFirst_Demo.Models;
using System.Collections.Generic;

namespace EFCore_DataBaseFirst_Demo
{
    internal interface IEmployeeRepository
    {
        public Student GetStudent(long studentId);
        public List<Student> GetStudents();

        public void CreateStudent(Student student);

        public void UpdateStudent(Student student);

        public void DeleteStudent(long studentId);
    }
}