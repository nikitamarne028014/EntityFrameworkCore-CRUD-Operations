using EntityFrameworkCoreDemo.Models;
using System;

namespace EFCore_DataBaseFirst_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Find student By Id
            var empProvider = new EmployeeRepository(new StudentDBContext());
            var student = empProvider.GetStudent(2);
            Console.WriteLine("Welcome "+student.StudentName + " your Roll Number is "+student.StudentRollNo);
            
            //Get All Students
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("StudentId \t StudentName \t StudentRollNo \t StudentDivision \t TeacherId");
            Console.WriteLine("----------------------------------------------------------------------------------------");
            var students = empProvider.GetStudents();
            foreach(var stud in students)
            {
                Console.WriteLine("\t"+stud.StudentId + "\t\t" + stud.StudentName + "\t\t" + stud.StudentRollNo + "\t\t" + stud.StudentDivision + "\t\t" + stud.TeacherId);
                Console.WriteLine("----------------------------------------------------------------------------------------");
            }

            //Create Student and Add to DB
            student = new Student("Jhon", 45, "B", 3);
            //empProvider.CreateStudent(student);

            //Update Student In Database
            student.StudentRollNo = 69;
            student.StudentDivision = "A";
            empProvider.UpdateStudent(student);

            //Delete Student From DB
            long id = 3; //specify Id present In DB here
            empProvider.DeleteStudent(id);
        }
    }
}
