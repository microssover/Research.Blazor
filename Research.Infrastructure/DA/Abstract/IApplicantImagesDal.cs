using Research.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Infrastructure.DA.Abstract
{
    public interface IApplicantImagesDal : IGenericDal<ApplicantImages>
    {
        Task<bool> CreateImage(ApplicantImages ApplicantImages);

        Task<List<ApplicantImages>> GetImageById(Guid applicantId);
    }
}
