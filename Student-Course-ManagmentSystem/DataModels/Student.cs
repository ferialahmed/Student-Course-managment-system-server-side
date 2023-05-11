using System;
using System.Collections.Generic;
namespace Student_Course_ManagmentSystem.DataModels
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set;}
        public int Age { get; set; }
        public string Gender { get; set; }  
        public ICollection<Grade> Grades { get; set; }
    }
}
