using AutoMapper;
using Company.Data.Entites;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Department.Dto;
using Company.Service.Interfaces.Employee.Dto;
using Company_Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Service.Services
{
    public class DepartmentService:IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void Add(DepartmentDto departmentDto)
        {
            //var mappedDepartment = new DepartmentDto
            //{
            //    Code = department.Code,
            //    Name = department.Name,
            //    CreateAt = DateTime.Now
            //};
            Department mappedDepartment = _mapper.Map<Department>(departmentDto);

            _unitOfWork.DepartmentRepository.Add(mappedDepartment);
            _unitOfWork.Complete();
        }

        public void Delete(DepartmentDto departmentDto)
        {
            Department mappedDepartment = _mapper.Map<Department>(departmentDto);

            _unitOfWork.DepartmentRepository.Delete(mappedDepartment);
            _unitOfWork.Complete();

        }

        public IEnumerable<DepartmentDto> GetAll()
        {

            var departments = _unitOfWork.DepartmentRepository.GetAll();
            IEnumerable<DepartmentDto> mappeddepartments = _mapper.Map<IEnumerable<DepartmentDto>>(departments);

            return mappeddepartments;
        }

        public DepartmentDto GetById(int? id)
        {
            if (id is null)
                return null;
            var department = _unitOfWork.DepartmentRepository.GetById(id.Value);
            if (department is null)
                return null;

            DepartmentDto departmentDto = _mapper.Map<DepartmentDto>(department);

            return departmentDto;
        }

        public void Update(DepartmentDto departmentDto)
        {
            //var dept = GetById(department.Id);
            //if (dept.Name != department.Name)
            //{
            //    if (GetAll().Any(x => x.Name == department.Name))
            //        throw new Exception("DuplicateDepartmentName");
            //}
            //dept.Name = department.Name;
            //dept.Code = department.Code;
            Department mappedDepartment = _mapper.Map<Department>(departmentDto);

            _unitOfWork.DepartmentRepository.Update(mappedDepartment);
            _unitOfWork.Complete();
        }
    }
}
