using Microsoft.EntityFrameworkCore;
using Research.Infrastructure.Context;
using Research.Infrastructure.DA.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Infrastructure.DA.Concrete
{
    public class GenericDal<T> : IGenericDal<T> where T : class
    {
        private ResearchDbContext _context;

        public GenericDal(ResearchDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Create(T t)
        {
            await _context.AddAsync(t);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(Guid id)
        {

            var response = await _context.Set<T>().FindAsync(id);
            _context.Remove(response);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<bool> Update(T t)
        {
            _context.Update(t);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
