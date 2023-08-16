namespace Task3.Services.Course
{
    public interface ICourseService
    {

        Task<List<Tables.Course>> GetAllCourses();
        Task<Tables.Course> GetCourseById(int id);
        Task<Tables.Course> AddCourse(Tables.Course Course);
        Task<Tables.Course> UpdateCourse(int id, Tables.Course Course);
        Task<Tables.Course> DeleteCourse(int id);

    }
}
