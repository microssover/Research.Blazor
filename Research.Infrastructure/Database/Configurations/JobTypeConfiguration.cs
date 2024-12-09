using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Research.Entity.Models;
using System.Reflection.Emit;

namespace Research.Infrastructure.Database.Configurations
{
    public class JobTypeConfiguration : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("JOBTYPE");
            builder.Property(e => e.ID).HasColumnName("ID");
            builder.Property(e => e.DESC).HasColumnName("DESC");
            builder.Property(e => e.DEPARTMENT_ID).HasColumnName("DEPARTMENT_ID");
            builder.Property(e => e.FLOW_ID).HasColumnName("FLOW_ID");
            builder.HasOne(e => e.Department)
                .WithMany(e => e.JobTypes)
                .HasForeignKey(e => e.DEPARTMENT_ID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(e => e.ApplicantFlow)
                .WithMany(e => e.JobTypes)
                .HasForeignKey(e => e.FLOW_ID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
