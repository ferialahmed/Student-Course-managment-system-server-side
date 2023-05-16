using Student_Course_ManagmentSystem.ControllerModels;
using Student_Course_ManagmentSystem.DataModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student_Course_ManagmentSystem.Repository.RegisterRepositories
{
    public interface IAssignStudent
    {
        Task<List<GradeDTO>> GetAll();
        Task<string> RegisterStudent(string studentId, string courseId, int grade);
    }
}
