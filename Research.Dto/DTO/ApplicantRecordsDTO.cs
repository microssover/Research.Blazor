using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Dto.DTO
{
    public class ApplicantRecordsDTO
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public STATUS Status { get; set; }
        public enum STATUS
        {
            Pending,
            Ongoing,
            Approved,
            Rejected
        };
        public string? Job_Type { get; set; }
        public DateTime Applicant_Date { get; set; }
        public Guid? Current_Flow_Id { get; set; }
        public Guid? JobTypeId { get; set; }

        public byte[]? ProfileImage { get; set; }

        public ApplicantFlowDTO? ApplicantFlowDto { get; set; }


    }
}

