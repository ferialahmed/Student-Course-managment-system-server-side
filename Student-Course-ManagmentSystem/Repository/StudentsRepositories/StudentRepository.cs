using Microsoft.EntityFrameworkCore;
using Student_Course_ManagmentSystem.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student_Course_ManagmentSystem.Repository.StudentsRepositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly DataContext db;
        public StudentRepository(DataContext _db)
        {
            db = _db;
        }
        public async Task<List<Student>> GetStudents()
        {
           
            return await db.Students.ToListAsync();
           
        }
        public async Task<string> AddStudent(string name, string gender, int age)
        {
            var student = new Student { Name = name, Gender = gender, Age = age};
            await db.Students.AddAsync(student);
            await db.SaveChangesAsync();
            return "Student registered successfully";
        }
    }
}
 
