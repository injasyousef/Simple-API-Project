using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Task3.Tables;

namespace Task3.Configuration
{
    public class CourseConf : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.IdCourse);

            builder.Property(v => v.NameCourse).HasMaxLength(200).IsRequired();



        }
    }
}
