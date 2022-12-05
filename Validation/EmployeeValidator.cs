using Demo.Models;
using FluentValidation;

namespace Demo.Validation;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(employee => employee.Name).NotNull();
        RuleFor(employee => employee.Code).NotNull();
        RuleFor(employee => employee.Email).NotNull();
    }
}