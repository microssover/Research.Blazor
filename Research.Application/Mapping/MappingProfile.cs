using AutoMapper;
using Research.Dto.DTO;
using Research.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Manager, ManagerDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.ID))
                .ForMember(d => d.Name, o => o.MapFrom(src => src.NAME))
                .ForMember(d => d.Surname, o => o.MapFrom(src => src.SURNAME))
                .ForMember(d => d.DepartmentDTO, o => o.MapFrom(src => src.Department));

            CreateMap<ManagerDTO, Manager>()
                .ForMember(d => d.ID, o => o.MapFrom(src => src.Id))
                .ForMember(d => d.NAME, o => o.MapFrom(src => src.Name))
                .ForMember(d => d.SURNAME, o => o.MapFrom(src => src.Surname))
                .ForMember(d => d.Department, o => o.MapFrom(src => src.DepartmentDTO));


            CreateMap<JobType, JobTypeDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.ID))
                .ForMember(d => d.Desc, o => o.MapFrom(src => src.DESC))
                .ForMember(d => d.Department_Id, o => o.MapFrom(src => src.DEPARTMENT_ID))
                .ForMember(d => d.DepartmentDTO, o => o.MapFrom(src => src.Department));

            CreateMap<JobTypeDTO, JobType>()
               .ForMember(d => d.ID, o => o.MapFrom(src => src.Id))
               .ForMember(d => d.DESC, o => o.MapFrom(src => src.Desc))
               .ForMember(d => d.DEPARTMENT_ID, o => o.MapFrom(src => src.Department_Id))
               .ForMember(d => d.Department, o => o.MapFrom(src => src.DepartmentDTO));


            CreateMap<Department, DepartmentDTO>()
               .ForMember(d => d.Id, o => o.MapFrom(src => src.ID))
               .ForMember(d => d.Name, o => o.MapFrom(src => src.NAME))
               .ForMember(d => d.Manager_Id, o => o.MapFrom(src => src.MANAGER_ID))
               .ForMember(d => d.ManagerDTO, o => o.MapFrom(src => src.Manager));
            
            CreateMap<DepartmentDTO, Department>()
               .ForMember(d => d.ID, o => o.MapFrom(src => src.Id))
               .ForMember(d => d.NAME, o => o.MapFrom(src => src.Name))
               .ForMember(d => d.MANAGER_ID, o => o.MapFrom(src => src.Manager_Id))
               .ForMember(d => d.Manager, o => o.MapFrom(src => src.ManagerDTO));


            CreateMap<ApplicantFlow, ApplicantFlowDTO>()
              .ForMember(d => d.Name, o => o.MapFrom(src => src.NAME))
              .ForMember(d => d.Id, o => o.MapFrom(src => src.ID))
              .ForMember(d => d.Next_Flow_Id, o => o.MapFrom(src => src.NEXT_FLOW_ID))
              .ForMember(d => d.Department_Id, o => o.MapFrom(src => src.DEPARTMENT_ID))
              .ForMember(d => d.DepartmentDto, o => o.MapFrom(src => src.Department));
            
            CreateMap<ApplicantFlowDTO, ApplicantFlow>()
              .ForMember(d => d.NAME, o => o.MapFrom(src => src.Name))
              .ForMember(d => d.ID, o => o.MapFrom(src => src.Id))
              .ForMember(d => d.NEXT_FLOW_ID, o => o.MapFrom(src => src.Next_Flow_Id))
              .ForMember(d => d.DEPARTMENT_ID, o => o.MapFrom(src => src.Department_Id))
              .ForMember(d => d.Department, o => o.MapFrom(src => src.DepartmentDto));

            CreateMap<ApplicantImages, ApplicantImagesDTO>().ReverseMap()
             .ForMember(d => d.ID, o => o.MapFrom(src => src.Id))
             .ForMember(d => d.APPLICANT_ID, o => o.MapFrom(src => src.Applicant_Id))
             .ForMember(d => d.PATH, o => o.MapFrom(src => src.Path));


            CreateMap<ApplicantRecords, ApplicantRecordsDTO>().ReverseMap()
             .ForMember(d => d.ID, o => o.MapFrom(src => src.Id))
             .ForMember(d => d.NAME, o => o.MapFrom(src => src.Name))
             .ForMember(d => d.SURNAME, o => o.MapFrom(src => src.Surname))
             .ForMember(d => d.EMAIL, o => o.MapFrom(src => src.Email))
             .ForMember(d => d.Status, o => o.MapFrom(src => src.Status))
             .ForMember(d => d.JOB_TYPE, o => o.MapFrom(src => src.Job_Type))
             .ForMember(d => d.PROFILE_IMAGE, o => o.MapFrom(src => src.ProfileImage))
             .ForMember(d => d.APPLICANT_DATE, o => o.MapFrom(src => src.Applicant_Date))
             .ForMember(d => d.CURRENT_FLOW_ID, o => o.MapFrom(src => src.Current_Flow_Id))
             .ForMember(d => d.JobTypeID, o => o.MapFrom(src => src.JobTypeId));
        }
    }
}
