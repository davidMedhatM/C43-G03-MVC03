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
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {
        private readonly CompanyDbContect _context;

        public DepartmentRepository(CompanyDbContect context) : base(context)
        {
            _context = context;
        }

    }
}
