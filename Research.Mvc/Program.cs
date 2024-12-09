using Microsoft.EntityFrameworkCore;
using Research.Application.Abstract;
using Research.Application.Contract;
using Research.Application.Mapping;
using Research.Infrastructure.Context;
using Research.Infrastructure.DA.Abstract;
using Research.Infrastructure.DA.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IApplicantRecordsService, ApplicantRecordsService>();
builder.Services.AddScoped<IApplicantRecordsDal, ApplicantRecordsDal>();

builder.Services.AddScoped<IApplicantImagesService, ApplicantImagesService>();
builder.Services.AddScoped<IApplicantImagesDal, ApplicantImagesDal>();

builder.Services.AddScoped<IJobTypeService, JobTypeService>();
builder.Services.AddScoped<IJobTypeDal, JobTypeDal>();
builder.Services.AddScoped<IJobTypeDal, JobTypeDal>();

builder.Services.AddScoped<IMailService, MailService>();

builder.Services.AddDbContext<ResearchDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ApplicantRecords}/{action=CreateApplicant}/{id?}");

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/ApplicantRecords");
        return;
    }
    await next();
});


app.Run();
