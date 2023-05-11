using System;

namespace Student_Course_ManagmentSystem.DataModels
{
    public class Grade
    {
        public int StudentID { get; set; }
        public Student Student { get; set; }

        public int CourseID { get; set; }
        public Course Course { get; set; }

        public decimal Score { get; set; }
    }
}