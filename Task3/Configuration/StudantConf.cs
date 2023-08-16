using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task3.Tables;

namespace Task3.Configuration
{
    public class StudantConf : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(c => c.IdStudent);

            builder.Property(v => v.NameStudent).HasMaxLength(200).IsRequired();



        }
    }
}
