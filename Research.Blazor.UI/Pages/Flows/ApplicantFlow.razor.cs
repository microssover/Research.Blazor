using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Research.Blazor.UI.Base;
using Research.Blazor.UI.Services.Abstract;
using Research.Dto.DTO;

namespace Research.Blazor.UI.Pages.Flows
{
    public partial class ApplicantFlow : RazorComponentBase
    {

        [Inject] private IApplicantFlowService _applicantFlowService { get; set; }
        [Inject] private IDepartmentService _departmentService { get; set; }
        [Inject] MainLayoutCascadingValue MainLayoutCascadingValue { get; set; }

        IEnumerable<ApplicantFlowDTO>? Flows;
        IEnumerable<DepartmentDTO>? Departments;
        private ApplicantFlowDTO CreateFlowRequest = new ApplicantFlowDTO();
        private ApplicantFlowDTO SelectedFlow = new ApplicantFlowDTO();
        public Guid? SelectedNextFlowId { get; set; }



        private Modal CreateFirstFlowModal = default!;
        private Modal UpdateFlowModal = default!;
        protected override async Task OnInitializedAsync()
        {
            Flows = await _applicantFlowService.GetFlows();
            Departments = await _departmentService.GetAll();
            await base.OnInitializedAsync();
        }


        async Task OpenCreateModal()
        {
            await CreateFirstFlowModal.ShowAsync();
        }
        async Task OpenUpdateModal(ApplicantFlowDTO ApplicantFlow)
        {
            SelectedFlow = ApplicantFlow;
            await UpdateFlowModal.ShowAsync();
        }
        async Task CloseModal()
        {
            await CreateFirstFlowModal.HideAsync();
            await UpdateFlowModal.HideAsync();
        }

        async Task LoadFlows()
        {
            Flows = await _applicantFlowService.GetFlows();
        }

        async Task CreateFlow()
        {
            try
            {
                var response = await _applicantFlowService.Create(new ApplicantFlowDTO
                {
                    Name = CreateFlowRequest.Name,
                    Id = Guid.NewGuid(),
                    Next_Flow_Id = SelectedNextFlowId ?? null,
                    Department_Id = CreateFlowRequest.Department_Id,
                });

                if (response)
                {
                    LayoutValue.ShowMessage("İş Akışı başarıyla kaydedildi !", MessageType.Success);
                    await CloseModal();
                    await LoadFlows();
                }

            }
            catch
            {
                LayoutValue.ShowMessage("İş Akışı kaydedilirken bir hata oluştu !", MessageType.Error);
            }
        }

        async Task Delete(Guid id)
        {
            try
            {
                var result = await _applicantFlowService.Delete(id);
                if (result)
                {
                    LayoutValue.ShowMessage("İş Akışı başarıyla silindi !", MessageType.Success);
                }
                else
                {
                    LayoutValue.ShowMessage("İş Akışını silmeden önce bağlı olduğu Departmanı silmeniz gerekmektedir. !", MessageType.Error);
                }
                await LoadFlows();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


        async Task Update()
        {
            if (SelectedFlow != null)
            {
                var response = await _applicantFlowService.Update(SelectedFlow);
                if (response)
                {
                    LayoutValue.ShowMessage("İş Akışı başarıyla güncellendi !", MessageType.Success);
                    await CloseModal();
                    await LoadFlows();
                }
                else
                {
                    LayoutValue.ShowMessage("İş Akışı güncellenirken hata oluştu !", MessageType.Error);
                }
            }
        }
    }
}
