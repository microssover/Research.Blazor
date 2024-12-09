using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Research.Blazor.UI.Base;
using Research.Blazor.UI.Services.Abstract;
using Research.Dto.DTO;

namespace Research.Blazor.UI.Pages.Manager
{
    public partial class Manager : RazorComponentBase
    {
        [Inject] private IManagerService _managerService { get; set; }
        [Inject] private IDepartmentService _departmentService { get; set; }
        [Inject] MainLayoutCascadingValue MainLayoutCascadingValue { get; set; }


        private Modal CreateManagerModal = default!;
        private Modal UpdateManagerModal = default!;

        private ManagerDTO CreateManagerRequest = new ManagerDTO();
        private ManagerDTO? EditManager;
        private ManagerDTO? SelectedManager = new ManagerDTO();

        IEnumerable<ManagerDTO>? Managers;
        IEnumerable<DepartmentDTO>? Departments;
        private Guid ManagerId;


        protected override async Task OnInitializedAsync()
        {
            Managers = await _managerService.GetManagers();
        }

        async Task OpenCreateModal()
        {
            await CreateManagerModal.ShowAsync();
        }

        async Task OpenUpdateModal(ManagerDTO Manager)
        {
            SelectedManager = Manager;
            await UpdateManagerModal.ShowAsync();
        }

        async Task LoadManagers()
        {
            Managers = await _managerService.GetManagers();
        }

        async Task CloseModal()
        {
            await CreateManagerModal.HideAsync();
            await UpdateManagerModal.HideAsync();
        }

        async Task Save()
        {
            try
            {
                var response = await _managerService.Create(new ManagerDTO()
                {
                    Name = CreateManagerRequest.Name,
                    Surname = CreateManagerRequest.Surname
                });
                await CloseModal();
                await LoadManagers();

                if (response)
                {
                    LayoutValue.ShowMessage("Yönetici başarıyla kaydedildi !", MessageType.Success);
                }
            }
            catch
            {
                LayoutValue.ShowMessage("Yönetici kaydedilirken bir hata oluştu !", MessageType.Error);
            }
        }

        async Task Update()
        {
            if (SelectedManager != null)
            {
                var response = await _managerService.Update(SelectedManager);
                if (response)
                {
                    await CloseModal();
                    LayoutValue.ShowMessage("Yönetici başarıyla güncellendi !", MessageType.Success);
                    await LoadManagers();
                }
                else
                {
                    LayoutValue.ShowMessage("Yönetici güncellenirken hata oluştu !", MessageType.Error);
                }
            }
        }

        async Task Delete(Guid id)
        {
            try
            {
                var result = await _managerService.Delete(id);
                await LoadManagers();
                if (result)
                {
                    LayoutValue.ShowMessage("Yönetici başarıyla silindi !", MessageType.Success);
                }
                else
                {
                    LayoutValue.ShowMessage("Yönetici silmeden önce departmanı silmeniz gerekmektedir !", MessageType.Error);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
