using Student_Course_ManagmentSystem.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student_Course_ManagmentSystem.Repository.CoursesRepositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCourses();
        Task<string> CreateCourse(string name, string description);
       
    }
}
