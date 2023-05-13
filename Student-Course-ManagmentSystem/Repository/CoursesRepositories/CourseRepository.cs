using Microsoft.EntityFrameworkCore;
using Student_Course_ManagmentSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student_Course_ManagmentSystem.Repository.CoursesRepositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext db;
        public CourseRepository(DataContext _db)
        {
            db = _db;
        }
        public async Task <List<Course>> GetCourses()
        {
            return await db.Courses.ToListAsync();
        }
        public async Task<string> CreateCourse(string name, string description)
        {         
            var course = new Course { Name = name, Description = description };
            await db.Courses.AddAsync(course);
            await db.SaveChangesAsync();
            return "Course has been added successfully";
        }
    }
}
