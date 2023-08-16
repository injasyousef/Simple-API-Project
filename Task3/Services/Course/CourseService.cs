using Microsoft.EntityFrameworkCore;

namespace Task3.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly AplicationDbContext _Context;

        public CourseService(AplicationDbContext dbContext)
        {
            _Context = dbContext;
        }

        public async Task<List<Tables.Course>> GetAllCourses()
        {
            return await _Context.Courses.Include(v=>v.Student_Course).ToListAsync();
        }

        public async Task<Tables.Course> GetCourseById(int id)
        {
            return await _Context.Courses.FirstOrDefaultAsync(c => c.IdCourse == id);
        }

        public async Task<Tables.Course> AddCourse(Tables.Course course)
        {
            _Context.Courses.Add(course);
            await _Context.SaveChangesAsync();
            return course;
        }

        public async Task<Tables.Course> UpdateCourse(int id, Tables.Course updatedCourse)
        {
            var course = await _Context.Courses.FirstOrDefaultAsync(c => c.IdCourse == id);
            if (course != null)
            {
                course.NameCourse= updatedCourse.NameCourse; 
                await _Context.SaveChangesAsync();
            }
            return course;
        }

        public async Task<Tables.Course> DeleteCourse(int id)
        {
            var course = await _Context.Courses.FirstOrDefaultAsync(c => c.IdCourse == id);
            if (course != null)
            {
                _Context.Courses.Remove(course);
                await _Context.SaveChangesAsync();
            }
            return course;
        }
    }
}
