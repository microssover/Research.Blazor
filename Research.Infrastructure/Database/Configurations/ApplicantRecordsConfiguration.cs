using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Research.Entity.Models;

namespace Research.Infrastructure.Database.Configurations
{
    public class ApplicantRecordsConfiguration : IEntityTypeConfiguration<ApplicantRecords>
    {
        public void Configure(EntityTypeBuilder<ApplicantRecords> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("APPLICANT_RECORDS");
            builder.Property(e => e.ID).HasColumnName("ID");
            builder.Property(e => e.NAME).HasColumnName("NAME");
            builder.Property(e => e.SURNAME).HasColumnName("SURNAME");
            builder.Property(e => e.EMAIL).HasColumnName("EMAIL");
            builder.Property(e => e.PROFILE_IMAGE).HasColumnName("PROFILE_IMAGE");
            builder.Property(e => e.Status).HasColumnName("Status").HasConversion<string>();
            builder.Property(e => e.JOB_TYPE).HasColumnName("JOB_TYPE");
            builder.Property(e => e.APPLICANT_DATE).HasColumnName("APPLICANT_DATE");
            builder.Property(e => e.CURRENT_FLOW_ID).IsRequired(false).HasColumnName("CURRENT_FLOW_ID");
            builder.HasMany(e => e.Applicant_Images)
            .WithOne(e => e.Applicant_Records);

            builder.HasOne(e => e.Applicant_Flow)
            .WithMany(e => e.Applicant_Records)
            .HasForeignKey(e => e.CURRENT_FLOW_ID)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
