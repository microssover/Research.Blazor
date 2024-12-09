using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Research.Entity.Models;

namespace Research.Infrastructure.Database.Configurations
{
    public class ManagerConfiguration : IEntityTypeConfiguration<Manager>
    {

        public void Configure(EntityTypeBuilder<Manager> builder)
        {
            builder.HasKey(e => e.ID);
            builder.ToTable("MANAGER");
            builder.Property(e => e.ID).HasColumnName("ID");
            builder.Property(e => e.NAME).HasColumnName("NAME");
            builder.Property(e => e.SURNAME).HasColumnName("SURNAME");

            builder.HasOne(e => e.Department)
                .WithOne(e => e.Manager)
                .HasForeignKey<Department>(e => e.MANAGER_ID);
        }
    }
}
