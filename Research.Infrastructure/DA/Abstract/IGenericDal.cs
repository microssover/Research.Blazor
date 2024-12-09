using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Infrastructure.DA.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task<bool> Create(T t);
        Task<bool> Update(T t);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
        Task<bool> Delete(Guid id);
    }
}
