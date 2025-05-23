﻿using Company.Data.Context;
using Company.Data.Entites;
using Company_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Repository.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContect _context;

        public EmployeeRepository(CompanyDbContect context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Employee> GetEmployeeByName(string name)
            => _context.Employees.Where(x =>
                x.Name.Trim().ToLower().Contains(name.Trim().ToLower())||
                x.Email.Trim().ToLower().Contains(name.Trim().ToLower())||
                x.PhoneNumber.Trim().ToLower().Contains(name.Trim().ToLower())
                ).ToList();

        public IEnumerable<Employee> GetEmployeesByAddress(string address)
        {
            throw new NotImplementedException();
        }
    }
}
