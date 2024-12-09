using Microsoft.EntityFrameworkCore;
using Research.Entity.Models;
using Research.Infrastructure.Context;
using Research.Infrastructure.DA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Infrastructure.DA.Concrete
{
    public class ApplicantImagesDal : GenericDal<ApplicantImages>, IApplicantImagesDal
    {
        private readonly ResearchDbContext _researchDbContext;
        public ApplicantImagesDal(ResearchDbContext context) : base(context)
        {
            _researchDbContext = context;
        }

        public async Task<bool> CreateImage(ApplicantImages ApplicantImages)
        {
            var applicantId = await _researchDbContext.APPLICANT_RECORDSs
                .Select(x => x.ID)
                .OrderByDescending(x => x)
                .FirstOrDefaultAsync();

            var newImages = new ApplicantImages
            {
                ID = ApplicantImages.ID,
                PATH = ApplicantImages.PATH,
                APPLICANT_ID = applicantId
            };

            await _researchDbContext.APPLICANT_IMAGESs.AddAsync(newImages);
            var result = await _researchDbContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<List<ApplicantImages>> GetImageById(Guid applicantId)
        {
            var images = await _researchDbContext.APPLICANT_IMAGESs
                .Where(x => x.APPLICANT_ID == applicantId)
                .Select(x => new ApplicantImages
                {
                    ID= x.ID,
                    APPLICANT_ID= x.APPLICANT_ID,
                    PATH = x.PATH,
                }).AsNoTracking().ToListAsync();

            return images;
        }
    }
}
