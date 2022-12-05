using Demo.Models;
using Demo.Request;

namespace Demo.Services.Employees;

public interface IEmployeeService
{
    Employee CreateEmployee(CreateEmployeeRequest employee);
    Employee? GetEmployee(Guid id);
    bool UpdateEmployee(Guid id, UpdateEmployeeRequest employee);
    void DeleteEmployee(Guid id);
    IEnumerable<Employee> GetAllEmployees();
    IEnumerable<Employee> GetActiveEmployees(int status);
    IEnumerable<Employee> GetDepartmentEmployees(int departmentId, int status);
}