using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Course_ManagmentSystem.ControllerModels;
using Student_Course_ManagmentSystem.DataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Student_Course_ManagmentSystem.Repository.StudentsRepositories;
using Student_Course_ManagmentSystem.Repository.CoursesRepositories;

namespace Student_Course_ManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository studentRepository;
        public StudentsController(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            try
            {
                var students = await studentRepository.GetStudents();
                if (students == null)
                {
                    return NotFound();
                }
                return Ok(students);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddStudents([FromBody] StudentModel student)
        {
            if (string.IsNullOrEmpty(student.Name) || string.IsNullOrEmpty(student.Gender) || student.Age == 0)
            {
                return BadRequest();
            }
            try
            {
                var result = await studentRepository.AddStudent(student.Name, student.Gender, student.Age);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}

