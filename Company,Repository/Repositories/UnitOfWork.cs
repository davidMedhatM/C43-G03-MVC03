using Company.Data.Context;
using Company_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Repository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContect _context;

        public UnitOfWork(CompanyDbContect context)
        {
            _context = context;
            DepartmentRepository=new DepartmentRepository(context);
            EmployeeRepository = new EmployeeRepository(context);
        }

        public IDepartmentRepository DepartmentRepository { get; set; }
        public IEmployeeRepository EmployeeRepository { get; set; }

        public int Complete()
            => _context.SaveChanges();
    }
}
