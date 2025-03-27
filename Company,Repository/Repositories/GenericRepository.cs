using Company.Data.Context;
using Company.Data.Entites;
using Company_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Repository.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly CompanyDbContect _context;

        public GenericRepository(CompanyDbContect context)
        {
            _context = context;
        }
        public void Add(T entity)
            => _context.Set<T>().Add(entity);

        public void Delete(T entity)
            => _context.Set<T>().Remove(entity);

        public IEnumerable<T> GetAll()
             => _context.Set<T>().ToList();

        public T GetById(int id)
        => _context.Set<T>().FirstOrDefault(x => x.Id == id);

        public void Update(T entity)
            => _context.Set<T>().Update(entity);
    }
}
