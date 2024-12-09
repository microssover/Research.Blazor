using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Research.Blazor.UI.Base;
using Research.Blazor.UI.Services.Abstract;
using Research.Dto.DTO;

namespace Research.Blazor.UI.Pages.Department
{
    public partial class Department : RazorComponentBase
    {
        [Inject] private IDepartmentService _departmentService { get; set; }
        [Inject] private IManagerService _managerService { get; set; }
        [Inject] MainLayoutCascadingValue MainLayoutCascadingValue { get; set; }


        private Modal CreateDepartmentModal = default!;
        private Modal UpdateDepartmentModal = default!;

        private DepartmentDTO CreateDepartmentRequest = new DepartmentDTO();
        private DepartmentDTO SelectedDepartment = new DepartmentDTO();

        IEnumerable<ManagerDTO>? Managers;
        IEnumerable<DepartmentDTO>? Departments;
        protected override async Task OnInitializedAsync()
        {
            Managers = await _managerService.GetAll();
            Departments = await _departmentService.GetDepartments();
        }

        async Task OpenCreateModal()
        {
            await CreateDepartmentModal.ShowAsync();
        }
        async Task OpenUpdateModal(DepartmentDTO Department)
        {
            SelectedDepartment = Department;
            await UpdateDepartmentModal.ShowAsync();
        }
        async Task LoadDepartments()
        {
            Departments = await _departmentService.GetDepartments();
        }

        async Task CloseModal()
        {
            await CreateDepartmentModal.HideAsync();
            await UpdateDepartmentModal.HideAsync();
        }
        async Task Save()
        {
            try
            {
                var response = await _departmentService.Create(new DepartmentDTO()
                {
                    Manager_Id = CreateDepartmentRequest.Manager_Id,
                    Name = CreateDepartmentRequest.Name
                });

                if (response)
                {
                    LayoutValue.ShowMessage("Departman başarıyla kaydedildi !", MessageType.Success);
                    await CloseModal();
                    await LoadDepartments();
                }
            }
            catch
            {
                LayoutValue.ShowMessage("Departman kaydedilirken bir hata oluştu !", MessageType.Error);
            }

        }

        async Task Delete(Guid id)
        {
            try
            {
                var result = await _departmentService.Delete(id);
                if (result)
                {
                    LayoutValue.ShowMessage("Departman başarıyla silindi !", MessageType.Success);
                }
                else
                {
                    LayoutValue.ShowMessage($"Departmandan önce iş akışını silmeniz gerekmektedir !", MessageType.Error);
                }
                await LoadDepartments();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        async Task Update()
        {
            if (SelectedDepartment != null)
            {
                var response = await _departmentService.Update(SelectedDepartment);
                if (response)
                {
                    await CloseModal();
                    LayoutValue.ShowMessage("Yönetici başarıyla güncellendi !", MessageType.Success);
                    await LoadDepartments();
                }
                else
                {
                    LayoutValue.ShowMessage("Yönetici güncellenirken hata oluştu !", MessageType.Error);
                }
            }
        }

    }
}
