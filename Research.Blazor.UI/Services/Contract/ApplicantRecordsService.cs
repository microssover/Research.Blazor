using Research.Blazor.UI.Services.Abstract;
using Research.Dto.DTO;
using System.Net.Http;
using System.Net.Http.Json;

namespace Research.Blazor.UI.Services.Contract
{

    public class ApplicantRecordsService : BaseService, IApplicantRecordsService
    {

        private readonly HttpClient _httpClient;
        private const string ApiName = "ApplicantRecords";

        public ApplicantRecordsService(HttpClient httpClient) : base(ApiName, httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Create(ApplicantRecordsDTO ApplicantRecordsDTO)
                => await PostAsync<ApplicantRecordsDTO, bool>("CreateApplicant", ApplicantRecordsDTO);

        public async Task<bool> Delete(Guid id)
            => await DeleteAsync<ApplicantRecordsDTO, bool>($"DeleteApplicant/{id}");

        public async Task<IEnumerable<ApplicantRecordsDTO>?> GetAll(Guid managerId)
              => await GetAsync<IEnumerable<ApplicantRecordsDTO>>($"GetAllApplicants?managerId={managerId}");

        public async Task<ApplicantRecordsDTO?> GetById(Guid id)
               => await GetAsync<ApplicantRecordsDTO>("GetApplicantById");


        public async Task<bool> Update(ApplicantRecordsDTO ApplicantRecordsDTO)
            => await PutAsync<ApplicantRecordsDTO, bool>("UpdateApplicant", ApplicantRecordsDTO);

        public async Task<bool> Reject(ApplicantRecordsDTO ApplicantRecordsDTO)
            => await PutAsync<ApplicantRecordsDTO, bool>($"RejectApplicant", ApplicantRecordsDTO);

        public async Task<IEnumerable<ApplicantRecordsDTO>?> GetApplicantByStatus()
            => await GetAsync<IEnumerable<ApplicantRecordsDTO>>("GetApplicantByStatus");

        public async Task<IEnumerable<ApplicantRecordsDTO>?> GetApprovedApplicants()
            => await GetAsync<IEnumerable<ApplicantRecordsDTO>>("GetApprovedApplicants");
    }
}
