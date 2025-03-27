using AutoMapper;
using Company.Data.Entites;
using Company.Service.Helper;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using Company_Repository.Interfaces;

namespace Company.Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public EmployeeDto GetById(int? id)
        {
            if (id <= 0)
                return null;
            var employee = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (employee is null)
                return null;
            //EmployeeDto employeeDto = new EmployeeDto
            //{
            //    Address = employee.Address,
            //    Age = employee.Age,
            //    DepartmentId = employee.DepartmentId,
            //    Email = employee.Email,
            //    HiringDate = employee.HiringDate,
            //    ImageUrl = employee.ImageUrl,
            //    Name = employee.Name,
            //    PhoneNumber = employee.PhoneNumber,
            //    Salary = employee.Salary,
            //    Id = employee.Id,
            //    CreateAt = employee.CreateAt
            //};
            EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public IEnumerable<EmployeeDto> GetAll()
        {

             var employees = _unitOfWork.EmployeeRepository.GetAll();
            //var mappedEmployees = employees.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    Id = x.Id,
            //    Address = x.Address,
            //    Age = x.Age,
            //    CreateAt = x.CreateAt
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return mappedEmployees;
        }

        public IEnumerable<EmployeeDto> GetEmployeeByName(string name)
        {
            var employee =  _unitOfWork.EmployeeRepository.GetEmployeeByName(name);
            //var mappedEmployees = employess.Select(x => new EmployeeDto
            //{
            //    DepartmentId = x.DepartmentId,
            //    Email = x.Email,
            //    HiringDate = x.HiringDate,
            //    ImageUrl = x.ImageUrl,
            //    Name = x.Name,
            //    PhoneNumber = x.PhoneNumber,
            //    Salary = x.Salary,
            //    Id = x.Id,
            //    Address = x.Address,
            //    Age = x.Age,
            //    CreateAt = x.CreateAt
            //});
            IEnumerable<EmployeeDto> mappedEmployees = _mapper.Map<IEnumerable<EmployeeDto>>(employee);

            return mappedEmployees;
        }

        public IEnumerable<EmployeeDto> GetEmployeesByAddress(string address)
        {
            var employess = _unitOfWork.EmployeeRepository.GetEmployeesByAddress(address);
            var mappedEmployees = employess.Select(x => new EmployeeDto
            {
                DepartmentId = x.DepartmentId,
                Email = x.Email,
                HiringDate = x.HiringDate,
                ImageUrl = x.ImageUrl,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Salary = x.Salary,
                Id = x.Id,
                Address = x.Address,
                Age = x.Age,
                CreateAt = x.CreateAt
            });
            return mappedEmployees;
        }

        //public void Add(EmployeeDto employee)
        //{
        //    employee.HiringDate = DateTime.Now; 
        //    _unitOfWork.EmployeeRepository.Add(employee);
        //    _unitOfWork.Complete();
        //}
        public void Add(EmployeeDto employeeDto)
        {
            // Manual Mapping
            //Employee employee = new Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //    Name = employeeDto.Name,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    Salary = employeeDto.Salary
            //};
            employeeDto.ImageUrl = DocumentSetting.UploadFile(employeeDto.Image, "Images");

            Employee employee =_mapper.Map<Employee>(employeeDto);
            _unitOfWork.EmployeeRepository.Add(employee);
            _unitOfWork.Complete();
        }
        public void Update(EmployeeDto employee)
        {
            //var existingEmployee = GetById(employee.Id);
            //if (existingEmployee is null)
            //    throw new Exception("EmployeeDto not found");

            //existingEmployee.Name = employee.Name;
            //existingEmployee.Age = employee.Age;
            //existingEmployee.Address = employee.Address;
            //existingEmployee.Salary = employee.Salary;
            //existingEmployee.Email = employee.Email;
            //existingEmployee.PhoneNumber = employee.PhoneNumber;
            //existingEmployee.ImageUrl = employee.ImageUrl;

            //_unitOfWork.EmployeeRepository.Update(existingEmployee);
            _unitOfWork.Complete();
        }

        public void Delete(EmployeeDto employeeDto)
        {
            //Employee employee = new Employee
            //{
            //    Address = employeeDto.Address,
            //    Age = employeeDto.Age,
            //    DepartmentId = employeeDto.DepartmentId,
            //    Email = employeeDto.Email,
            //    HiringDate = employeeDto.HiringDate,
            //    ImageUrl = employeeDto.ImageUrl,
            //    Name = employeeDto.Name,
            //    PhoneNumber = employeeDto.PhoneNumber,
            //    Salary = employeeDto.Salary
            //};

            //var existingEmployee = GetById(employee.Id);
            //if (existingEmployee is null)
            //    throw new Exception("EmployeeDto not found");
            Employee employee = _mapper.Map<Employee>(employeeDto);

            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }
    }
}
