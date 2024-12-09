using Microsoft.EntityFrameworkCore;
using Research.Entity.Models;
using System.Reflection;

namespace Research.Infrastructure.Context
{
    public class ResearchDbContext : DbContext
    {
      
        public ResearchDbContext(DbContextOptions<ResearchDbContext> options) : base(options)
        {
        }
        public virtual DbSet<ApplicantFlow> APPLICANT_FLOWs { get; set; }
        public virtual DbSet<ApplicantRecords> APPLICANT_RECORDSs { get; set; }
        public virtual DbSet<Department> DEPARTMENTs { get; set; }
        public virtual DbSet<ApplicantImages> APPLICANT_IMAGESs { get; set; }
        public virtual DbSet<JobType> JOBTYPEs { get; set; }
        public virtual DbSet<Manager> MANAGERs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(ResearchDbContext)));


            base.OnModelCreating(modelBuilder);

        }
    }
}


