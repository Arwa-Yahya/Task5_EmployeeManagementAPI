
using MediatR;
using Products.Application.DTOs;
using Products.Application.Interfaces;

namespace Products.Application.Employees
{
    public sealed record GetEmployeeByIdQuery(int Id) : IRequest<EmployeeDto?>;

    public sealed class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto?>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (employee is null)
                return null;

            return new EmployeeDto(employee.Id, employee.Name, employee.Position, employee.Salary);
        }
    }
}
