
using FluentValidation;

namespace Products.Application.Employees
{
    public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(employee => employee.Name)
                .NotEmpty()
                .WithMessage("Employee name is required.");

            RuleFor(employee => employee.Position)
                .NotEmpty()
                .WithMessage("Employee position is required.");

            RuleFor(employee => employee.Salary)
                .GreaterThan(0)
                .WithMessage("Employee salary must be greater than zero.");
        }
    }
}
