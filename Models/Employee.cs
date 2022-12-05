namespace Demo.Models;

public class Employee
{
    public Guid Id { get; }
    public string Name { get; }
    public string Code { get; }
    public string Mobile { get; }
    public string Email { get; }
    public string Address { get; }
    public bool Status { get; }
    public int DepartmentId { get; }
    public DateTime Birthdate { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public Employee(
        Guid id, 
        string name, 
        string code,
        string mobile,
        string email,
        string address,
        bool status,
        int departmentId,
        DateTime birthdate,
        DateTime createdAt,
        DateTime updatedAt)
    {
        Id = id;
        Name = name;
        Code = code;
        Mobile = mobile;
        Email = email;
        Address = address;
        Status = status;
        DepartmentId = departmentId;
        Birthdate = birthdate;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}