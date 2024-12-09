using Research.Dto.DTO;
using Research.Entity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Infrastructure.DA.Abstract
{
    public interface IManagerDal : IGenericDal<Manager>
    {
        Task<List<Manager>> GetManagers();
        Task<bool> UpdateManager(Manager Manager);
    }
}
