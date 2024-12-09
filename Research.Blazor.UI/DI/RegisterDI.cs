using Research.Blazor.UI.Services.Abstract;
using Research.Blazor.UI.Services.Contract;

namespace Research.Blazor.UI.DI
{
    public static class RegisterDI
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IJobTypeService, JobTypeService>();
            services.AddScoped<IApplicantFlowService, ApplicantFlowService>();
            services.AddScoped<IApplicantImagesService, ApplicantImagesService>();
            services.AddScoped<IApplicantRecordsService, ApplicantRecordsService>();
        }
    }
}
