using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTO.Employee;
using Project.BLL.Services.Contracts;
using Project.DAL.Entities.EmployeeEntity;
using Project.DAL.Entities.Shared.Enums;

namespace Project.Presentation.Controllers
{
    public class EmployeeController(
        IEmployeeService _service, 
        IWebHostEnvironment _environment,
        ILogger<EmployeeController> _logger) : Controller
    {
        public IActionResult Index()
        {
            var employees = _service.GetAllEmployees();
            // Binding through view's dictionary => transfer data from Action to View
            // 1. ViewData
            // 2. ViewBag
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create([FromServices] IDepartmentService departmentService)
        {
            ViewData["Departments"] = departmentService.GetAllDepartments(withTrack: false);
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeForCreationDto employeeDto)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    int result = _service.CreateEmployee(employeeDto);
                    // TempData => to send information from the current request to subsequent request
                    if (result > 0)
                    {
                        TempData["Message"] = "Employee Created Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    ModelState.AddModelError(string.Empty, "Can't Create Employee");
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else _logger.LogError(ex.Message);
                }
            }
            return View(employeeDto);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _service.GetEmployeeById(id.Value);
            return employee is null ? NotFound() : View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id, [FromServices] IDepartmentService departmentService)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _service.GetEmployeeById(id.Value);
            if(employee is null) return NotFound();
            ViewData["Departments"] = departmentService.GetAllDepartments(withTrack: false);
            var employeeDto = new EmployeeForUpdateDto()
            {
                Name = employee.Name,
                Address = employee.Address,
                Age = employee.Age.Value,
                Email = employee.Email,
                HiringDate = employee.HiringDate,
                IsActive = employee.IsActive,
                Phone = employee.PhoneNumber,
                Salary = employee.Salary,
                EmployeeType = Enum.Parse<EmployeeType>(employee.EmployeeType),
                Gender = Enum.Parse<Gender>(employee.Gender),
                DepartmentId = employee.DepartmentId
            };
            return View(employeeDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? id, EmployeeForUpdateDto employeeDto)
        {
            if(!id.HasValue) return BadRequest();
            if (!ModelState.IsValid) return View(employeeDto);
            try
            {
                bool result = _service.UpdateEmployee(id.Value, employeeDto);
                if (result)
                {
                    TempData["Message"] = "Employee Updated Successfully";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Employee Can't be Updated");
            }
            catch(Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return View(employeeDto);
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }
            return View(employeeDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // validate the request from any strange site that don't have the 
        // verfication token
        public IActionResult Delete(int id)
        {
            if(id == 0) return BadRequest();
            try
            {
                var deleted = _service.DeleteEmployee(id);
                if (deleted) return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "Employee Not deleted");
                return RedirectToAction(nameof(Delete), new { id = id });
            }
            catch(Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogError(ex.Message);
                    return View("ErrorView", ex);
                }
            }
        }
    }
}
