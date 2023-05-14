using Microsoft.EntityFrameworkCore;
using Student_Course_ManagmentSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student_Course_ManagmentSystem.Repository.RegisterRepositories
{
    public class AssignStudent : IAssignStudent
    {
        private readonly DataContext db;
        public AssignStudent(DataContext _db)
        {
            db = _db;
        }
        public async Task<List<Grade>> GetAll()
        {
            return await db.Grades.ToListAsync();
        }
        public async Task<string> RegisterStudent(string studentId, string courseId, int grade)
        {
            var registration = new Grade { StudentId = Guid.Parse(studentId), CourseId = Guid.Parse(courseId), Score = grade };
            await db.Grades.AddAsync(registration);
            await db.SaveChangesAsync();
            return "Student has been registered successfully";
        }
    }
}
