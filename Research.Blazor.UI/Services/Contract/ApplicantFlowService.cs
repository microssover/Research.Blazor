using Research.Blazor.UI.Services.Abstract;
using Research.Dto.DTO;
using System.Net.Http.Json;

namespace Research.Blazor.UI.Services.Contract
{
    public class ApplicantFlowService : BaseService, IApplicantFlowService
    {

        private readonly HttpClient _httpClient;
        private const string ApiName = "ApplicantFlow";

        public ApplicantFlowService(HttpClient httpClient) : base(ApiName, httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Create(ApplicantFlowDTO ApplicantFlowDTO)
                => await PostAsync<ApplicantFlowDTO, bool>("CreateApplicantFlow", ApplicantFlowDTO);

        public async Task<bool> Delete(Guid id)
            => await DeleteAsync<ApplicantFlowDTO, bool>($"DeleteApplicantFlow/{id}");

        public async Task<IEnumerable<ApplicantFlowDTO>?> GetAll()
              => await GetAsync<IEnumerable<ApplicantFlowDTO>>("GetApplicantFlows");

        public async Task<ApplicantFlowDTO?> GetById(Guid id)
               => await GetAsync<ApplicantFlowDTO>("GetApplicantFlowById");

        public async Task<bool> Update(ApplicantFlowDTO ApplicantFlowDTO)
            => await PutAsync<ApplicantFlowDTO, bool>("UpdateApplicantFlow", ApplicantFlowDTO);

        public async Task<IEnumerable<ApplicantFlowDTO>?> GetFlows()
             => await GetAsync<IEnumerable<ApplicantFlowDTO>>("GetFlows");


    }
}
