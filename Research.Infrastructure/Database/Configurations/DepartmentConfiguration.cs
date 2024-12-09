using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Research.Entity.Models;

namespace Research.Infrastructure.Database.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>

{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(e => e.ID);
        builder.ToTable("DEPARTMENT");
        builder.Property(e => e.ID).HasColumnName("ID");
        builder.Property(e => e.NAME).HasColumnName("NAME");
        builder.Property(e => e.MANAGER_ID).HasColumnName("MANAGER_ID");


        builder.HasMany(e => e.Applicant_Flows)
        .WithOne(e => e.Department)
        .HasForeignKey(e => e.DEPARTMENT_ID);

        builder.HasOne(e => e.Manager)
        .WithOne(e => e.Department)
        .HasForeignKey<Department>(e => e.MANAGER_ID);
    }
}
