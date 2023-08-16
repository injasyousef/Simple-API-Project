namespace Task3.Tables
{
    public class Course
    {
        public int IdCourse { get; set; }
        public string NameCourse { get; set; }

        public ICollection<Student_Course> Student_Course { get; set; } = new List<Student_Course>();



    }
}
