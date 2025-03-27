using Company.Data.Entites;
using Company.Service.Interfaces;
using Company.Service.Interfaces.Employee.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService,IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        public IActionResult Index(string searchInp)
        {
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            //ViewBag.Message = "viewbag";
            //ViewData["Text"] = "ViewData";
            //TempData["Data"] = "TempData";
            if (string.IsNullOrEmpty(searchInp))
                employees = _employeeService.GetAll();

            else
                employees = _employeeService.GetEmployeeByName(searchInp);

            return View(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();

            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeDto employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                return View(employee);
            }
        }


        public IActionResult Details(int? id, string viewName = "Details")
        {
            var employee = _employeeService.GetById(id);
            if (employee is null)
                return RedirectToAction("NotFoundPage", null, "Home");
            return View(viewName, employee);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }

        [HttpPost]
        public IActionResult Update(int? id, EmployeeDto employee)
        {
            if (employee.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");
            _employeeService.Update(employee);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee is null)
                return RedirectToAction("NotFoundPage", null, "Home");
            _employeeService.Delete(employee);
            return RedirectToAction(nameof(Index));
        }

    }
}
