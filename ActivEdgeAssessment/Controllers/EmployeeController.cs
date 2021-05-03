using ActivEdge.Data.services.interfaces;
using ActiveEdge.Models;
using ActiveEdge.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ActivEdgeAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepo employeeRepo, IMapper mapper)
        {
            _employeeRepo = employeeRepo;
            _mapper = mapper;
        }

        [Route("get-all-employees")]
        [HttpGet]
        public async Task<IActionResult> AllEmployees()
        {
            var dbResult = await _employeeRepo.GetAllEmployees();

            if (dbResult.Count < 1)
                return NotFound("No book record found in the database");

            var result = _mapper.Map<List<EmployeeDTO>>(dbResult);
            return Ok(result);
        }

        [Route("get-employee")]
        [HttpGet]
        public async Task<IActionResult> GetEmployee([FromBody] FindEmployeeDTO id)
        {
            if (!ModelState.IsValid)
                return BadRequest("An employee id is required to perform this operation");

            var employeeRecord = await _employeeRepo.GetAnEmployee(id.EmployeeId);

            if (employeeRecord == null)
                return NotFound("No such employee exist in the database");
            return Ok(employeeRecord);
        }

        [Route("add-employee")]
        [HttpPost]
        public async Task<IActionResult> AddAnEmployee([FromBody] EmployeeDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var empId = "";
            var lastId = 0;

            var dbResult = await _employeeRepo.GetAllEmployees();

            if (dbResult.Count < 1 || dbResult == null) empId = "E00001";

            else
            {
                lastId = int.Parse(dbResult[dbResult.Count - 1].EmployeeId.Replace("E0000", ""));
                empId = $"E0000{++lastId}";
            }

            var newEmployee = new Employee
            {
                EmployeeId = empId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Age = model.Age,
                Join_Date = model.Join_Date.ToString("yyyy-MM-dd")
            };

            var result = await _employeeRepo.CreateEmployee(newEmployee);

            if (!result)
                return BadRequest("Could not add the employee. Try again");

            return Ok("Employee has been added successfully");
        }

        [Route("update-employee")]
        [HttpPost]
        public async Task<IActionResult> UpdateEmployeeDetails([FromBody] EmployeeDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Employee fetchedEmployee = await _employeeRepo.GetAnEmployee(model.EmployeeId);

            if (fetchedEmployee == null)
                return NotFound("Employee with requested id was not found");

            var employeeToUpdate = _mapper.Map(model, fetchedEmployee);

            var result = await _employeeRepo.UpdateAnEmployee(employeeToUpdate);

            if (result)
                return Ok("Employee detail has been updated");

            return BadRequest("There was an error performing an update on the employee record");
        }

        [Route("delete-employee")]
        [HttpPost]
        public async Task<IActionResult> DeleteAnEmployee([FromBody] FindEmployeeDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Employee fetchedEmployee = await _employeeRepo.GetAnEmployee(model.EmployeeId);

            if (fetchedEmployee == null)
                return NotFound("Employee with requested id was not found");

            var deleteEmployee = await _employeeRepo.DeleteAnEmployee(fetchedEmployee);

            if (deleteEmployee)
                return Ok("Employee has been deleted successfully");

            return BadRequest("There was an error deleting the employee record");
        }
    }
}