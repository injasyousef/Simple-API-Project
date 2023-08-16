namespace Task3.Services.Student
{
    public interface IStudentService
    {

        Task<List<Tables.Student>> GetAllStudents();
        Task<Tables.Student> GetStudentById(int id);
        Task<Tables.Student> AddStudent(Tables.Student student);
        Task<Tables.Student> UpdateStudent(int id, Tables.Student student);
        Task<Tables.Student> DeleteStudent(int id);



    }
}
