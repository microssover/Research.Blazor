using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Research.Blazor.UI.Base;
using Research.Blazor.UI.Services.Abstract;
using Research.Dto.DTO;

namespace Research.Blazor.UI.Pages.JobType
{
    public partial class JobType : RazorComponentBase
    {
        [Inject] private IJobTypeService _jobTypeService { get; set; }
        [Inject] private IDepartmentService _departmentService { get; set; }
        [Inject] MainLayoutCascadingValue MainLayoutCascadingValue { get; set; }

        private Modal CreateJobTypeModal = default!;
        private Modal UpdateJobTypeModal = default!;
        private JobTypeDTO CreateJobTypeRequest = new JobTypeDTO();
        private JobTypeDTO SelectedJobType = new JobTypeDTO();


        IEnumerable<JobTypeDTO>? JobTypes;
        IEnumerable<DepartmentDTO>? Departments;

        private string? alert;

        protected override async Task OnInitializedAsync()
        {
            JobTypes = await _jobTypeService.GetJobTypes();
            Departments = await _departmentService.GetAll();
        }
        async Task OpenCreateModal()
        {
            await CreateJobTypeModal.ShowAsync();
        }

        async Task OpenUpdateModal(JobTypeDTO JobType)
        {
            SelectedJobType = JobType;
            await UpdateJobTypeModal.ShowAsync();
        }

        async Task CloseModal()
        {
            await CreateJobTypeModal.HideAsync();
            await UpdateJobTypeModal.HideAsync();
        }
        async Task LoadJobTypes()
        {
            JobTypes = await _jobTypeService.GetJobTypes();
        }
        async Task Save()
        {
            try
            {
                var response = await _jobTypeService.Create(new JobTypeDTO()
                {
                    Id = CreateJobTypeRequest.Id,
                    Desc = CreateJobTypeRequest.Desc,
                    Department_Id = CreateJobTypeRequest.Department_Id,
                    Flow_Id = CreateJobTypeRequest.Flow_Id
                });

                if (response)
                {
                    LayoutValue.ShowMessage("İş türü başarıyla oluşturuldu !", MessageType.Success);
                    await CloseModal();
                    await LoadJobTypes();
                }
            }
            catch
            {
                LayoutValue.ShowMessage("İş türü oluşturulurken bir hata oluştu !", MessageType.Error);
            }

        }

        async Task Delete(Guid id)
        {
            try
            {
                var result = await _jobTypeService.Delete(id);
                if (result)
                {
                    LayoutValue.ShowMessage("İş Türü başarıyla silindi !", MessageType.Success);
                }
                else
                {
                    LayoutValue.ShowMessage("İş Türünü silmeden önce bağlı olduğu İş Akışı ve Departmanı silmeniz gerekmektedir !", MessageType.Error);
                }

                await LoadJobTypes();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        async Task Update()
        {
            if (SelectedJobType != null)
            {
                var response = await _jobTypeService.Update(SelectedJobType);
                if (response)
                {
                    await CloseModal();
                    LayoutValue.ShowMessage("Yönetici başarıyla güncellendi !", MessageType.Success);
                    await LoadJobTypes();
                }
                else
                {
                    LayoutValue.ShowMessage("Yönetici güncellenirken hata oluştu !", MessageType.Error);
                }
            }
        }

    }
}
