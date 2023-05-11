using System;

namespace Student_Course_ManagmentSystem.DataModels
{
    public class Grade
    {
        public Guid StudentId { get; set; }
        public Student Student { get; set; }

        public Guid CourseId { get; set; }
        public Course Course { get; set; }

        public decimal? Score { get; set; }
    }
}