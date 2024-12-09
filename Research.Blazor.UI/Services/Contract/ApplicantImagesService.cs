using Research.Blazor.UI.Services.Abstract;
using Research.Dto.DTO;
using System.Net.Http;
using System.Net.Http.Json;

namespace Research.Blazor.UI.Services.Contract
{
    public class ApplicantImagesService : BaseService, IApplicantImagesService
    {
        private readonly HttpClient _httpClient;
        private const string ApiName = "ApplicantImages";

        public ApplicantImagesService(HttpClient httpClient) : base(ApiName, httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Create(ApplicantImagesDTO ApplicantImagesDTO)
                => await PostAsync<ApplicantImagesDTO, bool>("CreateApplicantImage", ApplicantImagesDTO);

        public async Task<bool> Delete(Guid id)
            => await DeleteAsync<ApplicantImagesDTO, bool>($"DeleteApplicantImage/{id}");

        public async Task<IEnumerable<ApplicantImagesDTO>?> GetAll()
              => await GetAsync<IEnumerable<ApplicantImagesDTO>>("GetAllApplicantImages");

        public async Task<IEnumerable<ApplicantImagesDTO>?> GetImageById(Guid applicantId)
               => await GetAsync<IEnumerable<ApplicantImagesDTO>>($"GetImageById?applicantId={applicantId}");


        public async Task<bool> Update(ApplicantImagesDTO ApplicantImagesDTO)
            => await PutAsync<ApplicantImagesDTO, bool>("UpdateApplicantImage", ApplicantImagesDTO);
    }
}
