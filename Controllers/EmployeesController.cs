using Demo.Models;
using Demo.Request;
using Demo.Services.Employees;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers;

[ApiController]
[Route("api")] 
public class EmployeesController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    
    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet("employees")]
    public IActionResult GetAllEmployees()
    {
        var employees = _employeeService.GetAllEmployees();
        return Ok(employees);
    }

    [HttpGet("employees/{status}")]
    public IActionResult GetEmployeesStatus(int status)
    {
        var employeesStatus = _employeeService.GetActiveEmployees(status);
        return Ok(employeesStatus);
    }

    [HttpGet("employees/{id:guid}")]
    public IActionResult GetEmployee(Guid id)
    {
        Employee? employee = _employeeService.GetEmployee(id);
        if (employee == null) return NotFound();

        return Ok(employee);
    }

    [HttpGet("department/{departmentId}/employees/{status}")]
    public IActionResult GetDepartmentEmployees(int departmentId, int status = 1)
    {
        var employees = _employeeService.GetDepartmentEmployees(departmentId, status);
        return Ok(employees);
    }

    [HttpPost("employees")]
    public IActionResult CreateEmployee(CreateEmployeeRequest request)
    {
        var employee = _employeeService.CreateEmployee(request);

        return CreatedAtAction(
            actionName: nameof(GetEmployee),
            routeValues: new { id = employee.Id},
            value: employee);
    }

    [HttpPut("employees/{id:guid}")]
    public IActionResult UpdateEmployee(Guid id, UpdateEmployeeRequest request)
    {
        var updatedEmployee = _employeeService.UpdateEmployee(id, request);
        if (updatedEmployee) return Ok(updatedEmployee);

        return NotFound();
    }

    [HttpDelete("employees/{id:guid}")]
    public IActionResult DeleteEmployee(Guid id)
    {
        _employeeService.DeleteEmployee(id);
        return NoContent();
    }
}