using Student_Course_ManagmentSystem.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student_Course_ManagmentSystem.Repository.StudentsRepositories
{
    public interface IStudentRepository
    {
            Task<List<Student>> GetStudents();
            Task<string> AddStudent(string name, string gender, int age);

        
    }
}
