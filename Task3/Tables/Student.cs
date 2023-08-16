namespace Task3.Tables
{
    public class Student
    {
        public int IdStudent { get; set; }
        public string NameStudent { get; set; }
        public ICollection<Student_Course> Student_Course { get; set; } = new List<Student_Course>();


    }
}
