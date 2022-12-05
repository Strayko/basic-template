using Demo.Models;
using Demo.Request;

namespace Demo.Services.Employees;

public class EmployeeService : IEmployeeService
{
    private static readonly List<Employee> _employees = new();
    public Employee CreateEmployee(CreateEmployeeRequest request)
    {
        var employee = new Employee(
            Guid.NewGuid(),
            request.Name,
            request.Code,
            request.Mobile,
            request.Email,
            request.Address,
            request.Status,
            request.DepartmentId,
            request.Birthdate,
            DateTime.UtcNow,
            DateTime.UtcNow);
        
        _employees.Add(employee);
        return employee;
    }

    public Employee? GetEmployee(Guid id)
    {
        return _employees.FirstOrDefault(e => e.Id == id);
    }

    public bool UpdateEmployee(Guid id, UpdateEmployeeRequest request)
    {
        var employee = new Employee(
            id,
            request.Name,
            request.Code,
            request.Mobile,
            request.Email,
            request.Address,
            request.Status,
            request.DepartmentId,
            request.Birthdate,
            request.CreatedAt,
            DateTime.UtcNow);
        
        int index = _employees.FindIndex(e => e.Id == employee.Id);
        if (index == -1) return false;
        
        _employees[index] = employee;
        return true;
    }

    public void DeleteEmployee(Guid id)
    {
        var employee = _employees.Single(e => e.Id == id);
        _employees.Remove(employee);
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        var employees = _employees.Select(e => e);
        return employees;
    }

    public IEnumerable<Employee> GetActiveEmployees(int status)
    {
        var requestStatus = ConvertToBoolean(status);
        return _employees.Where(e => e.Status == requestStatus);
    }

    public IEnumerable<Employee> GetDepartmentEmployees(int departmentId, int status)
    {
        bool requestStatus = ConvertToBoolean(status);
        var employees = _employees.Where(e => e.DepartmentId == departmentId)
            .Where(e => e.Status == requestStatus);
        
        return employees;
    }

    private bool ConvertToBoolean(int status)
    {
        var requestStatus = status switch
        {
            1 => "true",
            0 => "false",
            _ => ""
        };

        return bool.Parse(requestStatus);
    }
}