using Microsoft.EntityFrameworkCore;
using Student_Course_ManagmentSystem.ControllerModels;
using Student_Course_ManagmentSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Student_Course_ManagmentSystem.Repository.RegisterRepositories
{
    public class AssignStudent : IAssignStudent
    {
        private readonly DataContext db;
        public AssignStudent(DataContext _db)
        {
            db = _db;
        }
        public async Task<List<GradeDTO>> GetAll()
        {
            var grades = await db.Grades.Include(g => g.Student).Include(g => g.Course).ToListAsync();
            var gradeDTOs = grades.Select(g => new GradeDTO
            {
                StudentName = g.Student.Name,
                CourseName = g.Course.Name,
                GradeValue = (int)g.Score
            }).ToList();
            return gradeDTOs;
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
