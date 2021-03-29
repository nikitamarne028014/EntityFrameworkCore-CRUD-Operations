using EntityFrameworkCoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;


namespace EFCore_DataBaseFirst_Demo
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        private readonly StudentDBContext _studentDBContext;
        public EmployeeRepository(StudentDBContext studentDBContext)
        {
            _studentDBContext = studentDBContext;
        }

        public void CreateStudent(Student student)
        {
            _studentDBContext.Students.Add(student);
            _studentDBContext.SaveChanges();
        }

        public void DeleteStudent(long studentId)
        {
            var student = _studentDBContext.Students.Find(studentId);
            if(student != null)
            {
                _studentDBContext.Students.Remove(student);
                _studentDBContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("No Record Found to Be Deleted with StudentId " + studentId);
            }
        }

        public Student GetStudent(long studentId)
        {
            return _studentDBContext.Students.Find(studentId);
        }

        public List<Student> GetStudents()
        {
            List<Student> students_in_db = new List<Student>();
            var students = _studentDBContext.Students;
            foreach(Student student in students)
            {
                students_in_db.Add(student);
            }
            return students_in_db;
        }

        public void UpdateStudent(Student student)
        {
            _studentDBContext.Students.Update(student);
            _studentDBContext.SaveChanges();
        }
    }
}
