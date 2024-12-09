using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Research.Application.Abstract;
using Research.Application.Contract;
using Research.Infrastructure.Context;
using Research.Infrastructure.DA.Abstract;
using Research.Infrastructure.DA.Concrete;

namespace Research.Infrastructure.IoC
{
    public static class ServicesInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            //data access
            services.AddScoped<IManagerDal, ManagerDal>();
            services.AddScoped<IApplicantFlowDal, ApplicantFlowDal>();
            services.AddScoped<IApplicantImagesDal, ApplicantImagesDal>();
            services.AddScoped<IApplicantRecordsDal, ApplicantRecordsDal>();
            services.AddScoped<IJobTypeDal, JobTypeDal>();
            services.AddScoped<IDepartmentDal, DepartmentDal>();


            //services
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IJobTypeService, JobTypeService>();
            services.AddScoped<IApplicantFlowService, ApplicantFlowService>();
            services.AddScoped<IApplicantImagesService, ApplicantImagesService>();
            services.AddScoped<IApplicantRecordsService, ApplicantRecordsService>();
            services.AddScoped<IMailService, MailService>();


        }
        public static void AddDatabase( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ResearchDbContext>(options =>
            {
                var connectionString = configuration.GetConnectionString("DatabaseConnection");
                options.UseSqlServer(connectionString);
            });
        } 
    }
}
