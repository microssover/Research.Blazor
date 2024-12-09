using Research.Blazor.UI.Services.Abstract;
using Research.Dto.DTO;
using System.Net.Http.Json;

namespace Research.Blazor.UI.Services.Contract
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        private readonly HttpClient _httpClient;
        private const string ApiName = "Department";

        public DepartmentService(HttpClient httpClient) : base(ApiName, httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> Create(DepartmentDTO DepartmentDTO)
            => await PostAsync<DepartmentDTO, bool>("CreateDepartment", DepartmentDTO);

        public async Task<bool> Delete(Guid id)
            => await DeleteAsync<DepartmentDTO, bool>($"DeleteDepartment/{id}");

        public async Task<IEnumerable<DepartmentDTO>?> GetAll()
            => await GetAsync<IEnumerable<DepartmentDTO>>("GetAllDepartments");

        public async Task<DepartmentDTO?> GetById(Guid id)
            => await GetAsync<DepartmentDTO>("GetDepartmentById");

        public async Task<bool> Update(DepartmentDTO DepartmentDTO)
            => await PutAsync<DepartmentDTO, bool>("UpdateDepartment", DepartmentDTO);

        public async Task<IEnumerable<DepartmentDTO>?> GetDepartments()
            => await GetAsync<IEnumerable<DepartmentDTO>>("GetDepartments");


    }
}
