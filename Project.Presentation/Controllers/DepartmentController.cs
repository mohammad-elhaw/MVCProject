﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BLL.DTO.Department;
using Project.BLL.Services.Contracts;

namespace Project.Presentation.Controllers
{
    [Authorize]
    public class DepartmentController(
        IDepartmentService _departmentService, 
        ILogger<DepartmentController> _logger,
        IWebHostEnvironment _environment) : Controller
    {
        public IActionResult Index()
        {
            var departments = _departmentService.GetAllDepartments(withTrack: false);
            return View(departments);
        }
    
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DepartmentForCreationDto department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _departmentService.AddDepartment(department);
                    if (result > 0)
                    {
                        TempData["Message"] = "Department Created Successfully";
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can't be Created");
                    }
                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        // 1. Development => log error in console and return same view with error message
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        // 2. Deployment  => Log Error in file | Table in database and return Error view
                        _logger.LogError(ex.Message);
                    }
                }
            }
            return View(department);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value, withTrack: false);
            if (department is null) return NotFound();
            return View(department);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value, withTrack: true);
            if(department is null) return NotFound();
            var departmentDto = new DepartmentForUpdateDto()
            {
                Code = department.Code,
                Name = department.Name,
                Description = department.Description,
                DateOfCreation = department.CreatedOn
            };
            return View(departmentDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // action filter to verify the token that the browser send it (Verification_token) to ensure
        // only accept request from the browser that created the Verfication_token with the form
        public IActionResult Edit([FromRoute]int? id, DepartmentForUpdateDto departmentDto)
        {
            if (!ModelState.IsValid)
                return View(departmentDto);
            try
            {
                bool result = _departmentService.UpdateDepartment(id.Value, departmentDto, withTrack: true);
                if (result)
                {
                    TempData["Message"] = "Department Updated Successfully";
                    return RedirectToAction(nameof(Index));
                }
                else
                    ModelState.AddModelError(string.Empty, "Department can't be updated");
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else _logger.LogError(ex.Message);
            }
            return View(departmentDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool deleted = _departmentService.DeleteDepartment(id);
                if (deleted) return RedirectToAction(nameof(Index));
                ModelState.AddModelError(string.Empty, "Department Not deleted");
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
