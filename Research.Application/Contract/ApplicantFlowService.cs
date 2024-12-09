using AutoMapper;
using Research.Application.Abstract;
using Research.Dto.DTO;
using Research.Entity.Models;
using Research.Infrastructure.DA.Abstract;

namespace Research.Application.Contract;
public class ApplicantFlowService : IApplicantFlowService
{
    private readonly IApplicantFlowDal _applicantFlowDal;
    private readonly IMapper _mapper;

    public ApplicantFlowService(IApplicantFlowDal applicantFlowDal, IMapper mapper)
    {
        _applicantFlowDal = applicantFlowDal;
        _mapper = mapper;
    }

    public async Task<bool> Create(ApplicantFlowDTO ApplicantFlowDTO)
    {
        var applicantFlow = _mapper.Map<ApplicantFlow>(ApplicantFlowDTO);
        return await _applicantFlowDal.Create(applicantFlow);
    }

    public async Task<bool> Delete(Guid id)
    {
        return await _applicantFlowDal.Delete(id);
    }

    public async Task<List<ApplicantFlowDTO>> GetAll()
    {
        var applicantFlow = await _applicantFlowDal.GetAll();
        return _mapper.Map<List<ApplicantFlowDTO>>(applicantFlow);
    }
    
    public async Task<List<ApplicantFlowDTO>> GetFlows()
    {
        var applicantFlow = await _applicantFlowDal.GetFlows();
        return _mapper.Map<List<ApplicantFlowDTO>>(applicantFlow);
    }

    public async Task<ApplicantFlowDTO> GetById(Guid id)
    {
        var applicantFlow = await _applicantFlowDal.GetById(id);
        return _mapper.Map<ApplicantFlowDTO>(applicantFlow);   
    }

    public async Task<bool> Update(ApplicantFlowDTO ApplicantFlowDTO)
    {
        var applicantFlow = _mapper.Map<ApplicantFlow>(ApplicantFlowDTO);
        return await _applicantFlowDal.UpdateFlow(applicantFlow);
    }
}
