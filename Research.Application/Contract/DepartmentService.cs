using AutoMapper;
using Research.Application.Abstract;
using Research.Dto.DTO;
using Research.Entity.Models;
using Research.Infrastructure.DA.Abstract;

namespace Research.Application.Contract
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        private readonly IMapper _mapper;

        public DepartmentService(IDepartmentDal departmentDal, IMapper mapper)
        {
            _departmentDal = departmentDal;
            _mapper = mapper;
        }

        public async Task<bool> Create(DepartmentDTO DepartmentDTO)
        {
            var department = _mapper.Map<Department>(DepartmentDTO);
            return await _departmentDal.Create(department);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _departmentDal.Delete(id);
        }

        public async Task<List<DepartmentDTO>> GetAll()
        {
            var department = await _departmentDal.GetAll();
            return _mapper.Map<List<DepartmentDTO>>(department);
        }

        public async Task<DepartmentDTO> GetById(Guid id)
        {
            var department = await _departmentDal.GetById(id);
            var departmentDto = _mapper.Map<DepartmentDTO>(department);
            return departmentDto;
        }

        public async Task<List<DepartmentDTO>> GetDepartments()
        {
            var department = await _departmentDal.GetDepartments();
            var departmentDto = _mapper.Map<List<DepartmentDTO>>(department);
            return departmentDto;
        }

        public async Task<bool> Update(DepartmentDTO DepartmentDTO)
        {
            var manager = _mapper.Map<Department>(DepartmentDTO);
            return await _departmentDal.UpdateDepartment(manager);
        }
    }
}
