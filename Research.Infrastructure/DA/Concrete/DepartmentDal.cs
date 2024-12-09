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
    public class DepartmentDal : GenericDal<Department>, IDepartmentDal
    {
        private readonly ResearchDbContext _researchDbContext;
        public DepartmentDal(ResearchDbContext context) : base(context)
        {
            _researchDbContext = context;
        }

        public async Task<List<Department>> GetDepartments()
        {
            var response = await _researchDbContext.DEPARTMENTs
                .Select(x => new Department
                {
                    ID = x.ID,
                    NAME = x.NAME,
                    MANAGER_ID = x.MANAGER_ID,
                    Manager = new Manager
                    {
                        NAME = x.Manager.NAME,
                        SURNAME = x.Manager.SURNAME
                    }
                }).AsNoTracking().ToListAsync(); 

            return response;
        }

        public async Task<bool> UpdateDepartment(Department Department)
        {
            var department = await _researchDbContext.DEPARTMENTs.FirstOrDefaultAsync(x => x.ID == Department.ID);
            try
            {
                if (department != null)
                {
                    department.NAME = Department.NAME;
                    department.MANAGER_ID = Department.MANAGER_ID;
                }
                await _researchDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Güncelleme yapılırken bir hata oluştu ! {ex.Message}");
            }

            return true;
        }
    }
}
