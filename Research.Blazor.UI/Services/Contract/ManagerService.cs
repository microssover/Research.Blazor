using Research.Blazor.UI.Services.Abstract;
using Research.Dto.DTO;
using System.Net.Http;
using System.Net.Http.Json;

namespace Research.Blazor.UI.Services.Contract
{
    public class ManagerService : BaseService, IManagerService
    {

        private readonly HttpClient _httpClient;
        private const string ApiName = "Manager";

        public ManagerService(HttpClient httpClient) : base(ApiName, httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Create(ManagerDTO ManagerDTO)
                => await PostAsync<ManagerDTO, bool>("CreateManager", ManagerDTO);

        public async Task<bool> Delete(Guid id)
            => await DeleteAsync<ManagerDTO, bool>($"DeleteManager/{id}");

        public async Task<IEnumerable<ManagerDTO>?> GetAll()
              => await GetAsync<IEnumerable<ManagerDTO>>($"GetAllManagers");
        
        public async Task<IEnumerable<ManagerDTO>?> GetManagers()
              => await GetAsync<IEnumerable<ManagerDTO>>($"GetManagers");

        public async Task<ManagerDTO?> GetById(Guid id)
               => await GetAsync<ManagerDTO>("GetManagerById");

        public async Task<bool> Update(ManagerDTO ManagerDTO)
            => await PutAsync<ManagerDTO, bool>("UpdateManager", ManagerDTO);

        
    }
}
