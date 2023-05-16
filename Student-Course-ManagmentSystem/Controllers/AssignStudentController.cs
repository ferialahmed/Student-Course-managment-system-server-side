using Microsoft.AspNetCore.Mvc;
using Student_Course_ManagmentSystem.ControllerModels;
using Student_Course_ManagmentSystem.DataModels;
using Student_Course_ManagmentSystem.Repository.RegisterRepositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Student_Course_ManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignStudentController : ControllerBase
    {
        private readonly IAssignStudent registerRepository;
        public AssignStudentController(IAssignStudent _registerRepository)
        {
            registerRepository = _registerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Grade>>> GetAll()
        {
            try
            {
                var registeredStudents = await registerRepository.GetAll();
                if (registeredStudents == null)
                {
                    return NotFound();
                }
                return Ok(registeredStudents);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> RegisterStudent([FromBody] AssignStudentModel register)
        {
            try
            {
                var result = await registerRepository.RegisterStudent(register.StudentId, register.CourseId, register.Score);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
