using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Research.Entity.Models;
using System.Reflection.Emit;

namespace Research.Infrastructure.Database.Configurations
{
    public class ApplicantFlowConfiguration : IEntityTypeConfiguration<ApplicantFlow>
    {
        public void Configure(EntityTypeBuilder<ApplicantFlow> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("APPLICANT_FLOW");
            builder.Property(e => e.ID).HasColumnName("ID");
            builder.Property(e => e.NEXT_FLOW_ID).IsRequired(false).HasColumnName("NEXT_FLOW_ID");
            builder.Property(e => e.DEPARTMENT_ID).HasColumnName("DEPARTMENT_ID");
            builder.HasMany(e => e.Applicant_Records)
                .WithOne(e => e.Applicant_Flow);

            builder.HasOne(e => e.Department)
                .WithMany(e => e.Applicant_Flows)
                .HasForeignKey(e => e.DEPARTMENT_ID);
        }
    }
}
