using Microsoft.EntityFrameworkCore;
using Task3.Configuration;
using Task3.Tables;

namespace Task3
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> option) : base(option)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<Student_Course> StudentCourse { get; set; }
        public object Student_Course { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Studant_CourseConf());
            modelBuilder.ApplyConfiguration(new CourseConf());
            modelBuilder.ApplyConfiguration(new StudantConf());

            modelBuilder.Entity<Student>().HasData(new Student{
                IdStudent=1,
                NameStudent="Mohammad"
            });

        }
    }
}