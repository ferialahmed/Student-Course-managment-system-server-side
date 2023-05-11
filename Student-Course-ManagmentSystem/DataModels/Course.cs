using System;
using System.Collections.Generic;

namespace Student_Course_ManagmentSystem.DataModels
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}