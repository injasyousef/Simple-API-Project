using Microsoft.EntityFrameworkCore;

namespace Task3.Services.Student
{
    public class StudentService : IStudentService
    {
        private readonly AplicationDbContext _Context;

        public StudentService(AplicationDbContext Context)
        {
            _Context = Context;
        }

        public async Task<List<Tables.Student>> GetAllStudents()
        {
            return await _Context.Students.Include(c=>c.Student_Course).ToListAsync();
        }

        public async Task<Tables.Student> GetStudentById(int id)
        {
            return await _Context.Students.FirstOrDefaultAsync(c => c.IdStudent == id);
        }

        public async Task<Tables.Student> AddStudent(Tables.Student student)
        {
            _Context.Students.Add(student);
            await _Context.SaveChangesAsync();
            return student;
        }

        public async Task<Tables.Student> UpdateStudent(int id, Tables.Student updatedStudent)
        {
            var student = await _Context.Students.FirstOrDefaultAsync(c => c.IdStudent == id);
            if (student != null)
            {
                student.NameStudent = updatedStudent.NameStudent;
                await _Context.SaveChangesAsync();
            }
            return student;
        }

        public async Task<Tables.Student> DeleteStudent(int id)
        {
            var student = await _Context.Students.FirstOrDefaultAsync(c => c.IdStudent == id);
            if (student != null)
            {
                _Context.Students.Remove(student);
                await _Context.SaveChangesAsync();
            }
            return student;
        }
    }
}
