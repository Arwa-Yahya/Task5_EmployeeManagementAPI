
using MediatR;
using Products.Application.DTOs;
using Products.Application.Interfaces;
using Products.Domain.Entities;

namespace Products.Application.Employees
{
    public sealed record CreateEmployeeCommand(string Name, string Position, decimal Salary) : IRequest<EmployeeDto>;

    public sealed class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, EmployeeDto>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public CreateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = new Employee(request.Name, request.Position, request.Salary);

            await _employeeRepository.AddAsync(employee, cancellationToken);

            return new EmployeeDto(employee.Id, employee.Name, employee.Position, employee.Salary);
        }
    }
}
