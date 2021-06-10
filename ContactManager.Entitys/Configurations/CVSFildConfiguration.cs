using ContactManager.Entitys.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManager.Entitys.Configurations
{
    public class CVSFildConfiguration : IEntityTypeConfiguration<CSVEntityFild>
    {
        public void Configure(EntityTypeBuilder<CSVEntityFild> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DateofBirth)
                .IsRequired();
            builder.Property(x => x.Name)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(x => x.Phone)
                .HasMaxLength(15)
                .IsRequired();
            //builder.Property(x => x.Married)
            //   .HasValueGenerator(typeof(bool));
            builder.Property(x => x.Salary)
                .IsRequired();
        }
    }
}