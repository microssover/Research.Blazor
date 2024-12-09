using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Research.Entity.Models;

namespace Research.Infrastructure.Database.Configurations
{
    public class ApplicantImagesConfiguration : IEntityTypeConfiguration<ApplicantImages>
    {
        public void Configure(EntityTypeBuilder<ApplicantImages> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("APPLICANT_IMAGES");
            builder.Property(e => e.ID).HasColumnName("ID");
            builder.Property(e => e.APPLICANT_ID).HasColumnName("APPLICANT_ID");
            builder.Property(e => e.PATH).HasColumnName("PATH");
            builder.HasOne(e => e.Applicant_Records)
            .WithMany(e => e.Applicant_Images)
            .HasForeignKey(e => e.APPLICANT_ID);
        }
    }
}
