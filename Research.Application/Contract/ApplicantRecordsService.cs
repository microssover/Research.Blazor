using AutoMapper;
using Research.Application.Abstract;
using Research.Common.Enums;
using Research.Dto.DTO;
using Research.Entity.Models;
using Research.Infrastructure.DA.Abstract;

namespace Research.Application.Contract
{
    public class ApplicantRecordsService : IApplicantRecordsService
    {
        private readonly IApplicantRecordsDal _applicantRecordsDal;
        private readonly IMailService _mailService;
        private readonly IMapper _mapper;

        public ApplicantRecordsService(IApplicantRecordsDal applicantRecordsDal, IMapper mapper, IMailService mailService)
        {
            _applicantRecordsDal = applicantRecordsDal;
            _mapper = mapper;
            _mailService = mailService;
        }

        public async Task<bool> Create(ApplicantRecordsDTO ApplicantRecordsDTO)
        {
            var applicantRecords = _mapper.Map<ApplicantRecords>(ApplicantRecordsDTO);
            return await _applicantRecordsDal.CreateApplicant(applicantRecords);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _applicantRecordsDal.Delete(id);
        }

        public async Task<List<ApplicantRecordsDTO>> GetAll(Guid managerId)
        {
            var records = await _applicantRecordsDal.GetListForApplicantGrid(managerId);
            return _mapper.Map<List<ApplicantRecordsDTO>>(records);
        }

        public async Task<ApplicantRecordsDTO> GetById(Guid id)
        {
            var applicantRecords = await _applicantRecordsDal.GetById(id);
            var applicantRecordsDto = _mapper.Map<ApplicantRecordsDTO>(applicantRecords);
            return applicantRecordsDto;
        }

        public async Task<bool> Update(ApplicantRecordsDTO ApplicantRecordsDTO)
        {
            var applicantRecords = _mapper.Map<ApplicantRecords>(ApplicantRecordsDTO);

            var updateResult = await _applicantRecordsDal.UpdateApplicantForApprovement(applicantRecords);

            if (updateResult)
            {
                if (applicantRecords.Status == Common.Enums.ApplicantRecordFlow.Approved)
                {
                    await _mailService.SendEmail("ahmettayyip73@gmail.com", applicantRecords.NAME, applicantRecords.SURNAME);
                }
            }

            return updateResult;

        }

        public async Task<bool> Reject(ApplicantRecordsDTO ApplicantRecordsDTO)
        {
            var rejectApplicant = _mapper.Map<ApplicantRecords>(ApplicantRecordsDTO);
            return await _applicantRecordsDal.RejectApplicantOnApprovement(rejectApplicant);
        }

        public async Task<List<ApplicantRecordsDTO>> GetApprovedAndRejected()
        {
            var records = await _applicantRecordsDal.GetListForApplicantStatus();
            return _mapper.Map<List<ApplicantRecordsDTO>>(records);
        }

        public async Task<List<ApplicantRecordsDTO>> GetApprovedApplicants()
        {
            var records = await _applicantRecordsDal.GetListForApplicantApproved();
            var applicants = _mapper.Map<List<ApplicantRecordsDTO>>(records);

            foreach (var applicant in applicants)
            {
                string subject = "Başvurunuz onaylanmıştır.";
                string body = $"Sevgili {applicant.Name} {applicant.Surname}, başvurunuz onaylanmıştır. Tebrik ederiz.";

                await _mailService.SendEmail("ahmettayyip73@gmail.com", subject, body);
            }
            return applicants;
        }
    }
}
