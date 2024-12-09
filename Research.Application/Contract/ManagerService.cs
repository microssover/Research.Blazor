using AutoMapper;
using Research.Application.Abstract;
using Research.Dto.DTO;
using Research.Entity.Models;
using Research.Infrastructure.DA.Abstract;

namespace Research.Application.Contract
{
    public class ManagerService : IManagerService
    {
        private IManagerDal _managerDal;
        private readonly IMapper _mapper;

        public ManagerService(IManagerDal managerDal, IMapper mapper)
        {
            _managerDal = managerDal;
            _mapper = mapper;

        }

        public async Task<bool> Create(ManagerDTO ManagerDTO)
        {
            var manager = _mapper.Map<Manager>(ManagerDTO);
            return await _managerDal.Create(manager);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _managerDal.Delete(id);
        }

        public async Task<List<ManagerDTO>> GetAll()
        {
            var manager = await _managerDal.GetAll();
            return _mapper.Map<List<ManagerDTO>>(manager);

        }
        public async Task<List<ManagerDTO>> GetManagers()
        {
            var manager = await _managerDal.GetManagers();
            return _mapper.Map<List<ManagerDTO>>(manager);
        }


        public async Task<ManagerDTO> GetById(Guid id)
        {
            var manager = await _managerDal.GetById(id);
            var managerDto = _mapper.Map<ManagerDTO>(manager);
            return managerDto;
        }

        public async Task<bool> Update(ManagerDTO ManagerDTO)
        {
            var manager = _mapper.Map<Manager>(ManagerDTO);
            return await _managerDal.UpdateManager(manager);
        }
    }
}
