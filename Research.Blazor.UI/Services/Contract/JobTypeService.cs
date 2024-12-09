using Research.Blazor.UI.Services.Abstract;
using Research.Dto.DTO;
using System.Net.Http;
using System.Net.Http.Json;

namespace Research.Blazor.UI.Services.Contract
{
    public class JobTypeService : BaseService, IJobTypeService
    {
        private readonly HttpClient _httpClient;
        private const string ApiName = "JobType";

        public JobTypeService(HttpClient httpClient) : base(ApiName, httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Create(JobTypeDTO JobTypeDTO)
                => await PostAsync<JobTypeDTO, bool>("CreateJobType", JobTypeDTO);

        public async Task<bool> Delete(Guid id)
            => await DeleteAsync<JobTypeDTO, bool>($"DeleteJobType/{id}");

        public async Task<IEnumerable<JobTypeDTO>?> GetAll()
              => await GetAsync<IEnumerable<JobTypeDTO>>("GetAllJobTypes");

        public async Task<JobTypeDTO?> GetById(Guid id)
               => await GetAsync<JobTypeDTO>("GetJobTypeById");


        public async Task<bool> Update(JobTypeDTO JobTypeDTO)
            => await PutAsync<JobTypeDTO, bool>("UpdateJobType", JobTypeDTO);

        public async Task<IEnumerable<JobTypeDTO>?> GetJobTypes()
            => await GetAsync<IEnumerable<JobTypeDTO>>("GetJobTypes");

    }
}
