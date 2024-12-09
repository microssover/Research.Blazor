using BlazorBootstrap;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Research.Blazor.UI.Base;
using Research.Blazor.UI.Services.Abstract;
using Research.Common.Enums;
using Research.Dto.DTO;


namespace Research.Blazor.UI.Pages.AdminPanel
{
    public partial class AdminPanel : RazorComponentBase
    {
        [Inject] private IManagerService _managerService { get; set; }
        [Inject] private IApplicantRecordsService _applicantRecordsService { get; set; }
        [Inject] private IApplicantImagesService _applicantImagesService { get; set; }
        [Inject] MainLayoutCascadingValue MainLayoutCascadingValue { get; set; }
        [Inject] private ILocalStorageService _localStorageService { get; set; }

        private Guid selectedManager;
        private ApplicantRecordsDTO recordDTO = new ApplicantRecordsDTO();

        IEnumerable<ApplicantRecordsDTO>? DecidedApplicants;
        IEnumerable<ApplicantRecordsDTO>? Applicants;
        IEnumerable<ManagerDTO>? Managers;
        IEnumerable<ApplicantImagesDTO>? Images;

        private Modal ShowApplicantImages = default!;

        protected override async Task OnInitializedAsync()
        {
            DecidedApplicants = await _applicantRecordsService.GetApplicantByStatus();
            Managers = await _managerService.GetAll();
            await GetApprovedApplicants();

            var storedManagerName = await _localStorageService.GetItemAsync<string>("SelectedManagerName");
            var storedManagerId = await _localStorageService.GetItemAsync<Guid>("SelectedManagerId");

            if (storedManagerId != Guid.Empty)
            {
                selectedManager = storedManagerId;
                await LoadApplicants(selectedManager);
            }
            else
            {
                selectedManager = Guid.Empty;
            }

        }

        async Task OpenImages(Guid applicantId)
        {
            await ShowApplicantImages.ShowAsync();
            await LoadImages(applicantId);
        }

        private async Task HandleManagerSelect(ChangeEventArgs e)
        {
            try
            {
                selectedManager = Guid.Parse(e.Value?.ToString() ?? Guid.Empty.ToString());

                if (selectedManager != Guid.Empty)
                    await _localStorageService.SetItemAsync("SelectedManagerId", selectedManager);


                await LoadApplicants(selectedManager);
            }
            catch
            {
                LayoutValue.ShowMessage("Yönetici değiştirilirken bir hata oluştu !", MessageType.Error);
            }
        }

        private async Task LoadImages(Guid applicantId)
        {
            try
            {
                if (applicantId != Guid.Empty)
                {
                    Images = await _applicantImagesService.GetImageById(applicantId);
                }
            }
            catch
            {
                LayoutValue.ShowMessage("Resimler getirilirken bir hata oluştu !", MessageType.Error);
            }
        }

        private async Task LoadApplicants(Guid managerId)
        {
            try
            {
                if (managerId != Guid.Empty)
                {
                    Applicants = await _applicantRecordsService.GetAll(managerId);
                }
            }
            catch
            {
                LayoutValue.ShowMessage("Başvuranlar yüklenirken bir hata oluştu !", MessageType.Error);
            }
        }

        private async Task ApproveApplicant(ApplicantRecordsDTO ApplicantRecordsDTO)
        {
            try
            {
                await _applicantRecordsService.Update(ApplicantRecordsDTO);
                LayoutValue.ShowMessage("Başvuran başarıyla güncellendi !", MessageType.Success);
                await LoadApplicants(selectedManager);
                await GetApprovedApplicants();
            }
            catch
            {
                LayoutValue.ShowMessage("Başvuran güncellenirken bir hata oluştu ! ", MessageType.Success);
            }
        }

        async Task DeleteApplicant(Guid id)
        {
            try
            {
                await _applicantRecordsService.Delete(id);
                LayoutValue.ShowMessage("Başvuran başarıyla silindi !", MessageType.Success);
                await LoadApplicants(selectedManager);
            }
            catch
            {
                LayoutValue.ShowMessage("Başvuran silinirken bir hata oluştu !", MessageType.Error);
            }

        }

        async Task RejectApplicant(ApplicantRecordsDTO ApplicantRecordsDTO)
        {
            try
            {
                await _applicantRecordsService.Reject(ApplicantRecordsDTO);
                LayoutValue.ShowMessage("Başvuran reddedildi !", MessageType.Success);
                await LoadApplicants(selectedManager);
                await GetApprovedApplicants();
            }
            catch
            {
                LayoutValue.ShowMessage("Başvuran reddetme işlemi sırasında bir hata oluştu !", MessageType.Error);
            }
        }

        async Task GetApprovedApplicants()
        {
            try
            {
                DecidedApplicants = await _applicantRecordsService.GetApplicantByStatus();
            }
            catch
            {
                LayoutValue.ShowMessage("Mail gönderilirken bir hata oluştu !", MessageType.Error);
            }
        }
    }
}
