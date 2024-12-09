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
    public class ManagerDal : GenericDal<Manager>, IManagerDal
    {
        private readonly ResearchDbContext _researchDbContext;
        public ManagerDal(ResearchDbContext context) : base(context)
        {
            _researchDbContext = context;
        }

        public async Task<List<Manager>> GetManagers()
        {
            var response = await _researchDbContext.MANAGERs
                .Select(x => new Manager
                {
                    ID = x.ID,
                    NAME = x.NAME,
                    SURNAME = x.SURNAME,
                    Department = new Department
                    {
                        NAME = x.Department.NAME,
                    }
                }).AsNoTracking().ToListAsync(); 

            return response;
        }

        public async Task<bool> UpdateManager(Manager Manager)
        {
            var manager = await _researchDbContext.MANAGERs.FirstOrDefaultAsync(x => x.ID == Manager.ID);
            try
            {
                if (manager != null)
                {
                    manager.NAME = Manager.NAME;
                    manager.SURNAME = Manager.SURNAME;
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
