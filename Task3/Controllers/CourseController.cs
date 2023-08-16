using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task3.Services.Course;
using Task3.Tables;

namespace Task3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _courseService.GetAllCourses();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseById(id);
            if (course == null)
                return NotFound();

            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] Course course)
        {
            if (course == null)
                return BadRequest();

            var addedCourse = await _courseService.AddCourse(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = addedCourse.IdCourse }, addedCourse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] Course course)
        {
            if (course == null || course.IdCourse != id)
                return BadRequest();

            var updatedCourse = await _courseService.UpdateCourse(id, course);
            if (updatedCourse == null)
                return NotFound();

            return Ok(updatedCourse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var deletedCourse = await _courseService.DeleteCourse(id);
            if (deletedCourse == null)
                return NotFound();

            return Ok(deletedCourse);
        }
    }
}
