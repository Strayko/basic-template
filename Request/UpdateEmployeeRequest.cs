namespace Demo.Request;

public record UpdateEmployeeRequest(
    string Name,
    string Code,
    string Mobile,
    string Email,
    string Address,
    bool Status,
    int DepartmentId,
    DateTime Birthdate,
    DateTime CreatedAt,
    DateTime UpdatedAt);