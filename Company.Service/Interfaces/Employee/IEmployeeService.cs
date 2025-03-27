using Company.Data.Entites;
using Company.Service.Interfaces.Employee.Dto;

namespace Company.Service.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDto GetById(int? id);
        IEnumerable<EmployeeDto> GetAll();
        IEnumerable<EmployeeDto> GetEmployeeByName(string name);
        IEnumerable<EmployeeDto> GetEmployeesByAddress(string address);
        void Add(EmployeeDto employee);
        void Update(EmployeeDto employee);
        void Delete(EmployeeDto employee);
    }
}
