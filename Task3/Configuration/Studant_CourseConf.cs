using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task3.Tables;

namespace Task3.Configuration
{
    public class Studant_CourseConf : IEntityTypeConfiguration<Student_Course>
    {
        public void Configure(EntityTypeBuilder<Student_Course> builder)
        {
            builder.HasKey(sc => new { sc.IdCourse, sc.IdStudent });

            builder
            .HasOne(sc => sc.Student)
            .WithMany(s => s.Student_Course)
            .HasForeignKey(sc => sc.IdStudent);

            builder.HasOne(sc => sc.course)
            .WithMany(c => c.Student_Course)
            .HasForeignKey(sc => sc.IdCourse);


        }
    }
}
