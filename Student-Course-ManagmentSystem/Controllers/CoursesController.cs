using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student_Course_ManagmentSystem.ControllerModels;
using Student_Course_ManagmentSystem.DataModels;
using Student_Course_ManagmentSystem.Repository.CoursesRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Student_Course_ManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;
        public CoursesController(ICourseRepository _courseRepository)
        {
            courseRepository = _courseRepository;
        }

        [HttpGet]       
        public async Task<ActionResult<List<Course>>> GetCourses()
        {
            try
            {
                var courses = await courseRepository.GetCourses();
                if (courses == null)
                {
                    return NotFound();
                }
                return Ok(courses);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseModel course)
        {
            if (string.IsNullOrEmpty(course.Name) || string.IsNullOrEmpty(course.Description) ) {
                return BadRequest();
            }
            try
            {
                var result = await courseRepository.CreateCourse(course.Name, course.Description);
                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }   
        }
        
    }
}
