
using MediatR;
using Products.Application.DTOs;
using Products.Application.Interfaces;

namespace Products.Application.Employees
{
    public sealed record UpdateEmployeeCommand(int Id, string Name, string Position, decimal Salary) : IRequest<EmployeeDto?>;

    public sealed class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, EmployeeDto?>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto?> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (employee is null)
                return null;

            employee.Update(request.Name, request.Position, request.Salary);

            await _employeeRepository.UpdateAsync(employee, cancellationToken);

            return new EmployeeDto(employee.Id, employee.Name, employee.Position, employee.Salary);
        }
    }
}
