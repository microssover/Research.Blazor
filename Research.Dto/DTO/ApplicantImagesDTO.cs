using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Dto.DTO
{
    public class ApplicantImagesDTO
    {
        public Guid Id { get; set; }
        public Guid? Applicant_Id{ get; set; }
        public string? Path { get; set; }
    }
}
