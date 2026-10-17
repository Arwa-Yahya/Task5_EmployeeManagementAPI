
using MediatR;
using Products.Application.DTOs;
using Products.Application.Interfaces;

namespace Products.Application.Employees
{
    public sealed record GetAllEmployeesQuery : IRequest<IReadOnlyList<EmployeeDto>>;

    public sealed class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IReadOnlyList<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IReadOnlyList<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync(cancellationToken);

            return employees
                .Select(employee => new EmployeeDto(employee.Id, employee.Name, employee.Position, employee.Salary))
                .ToList();
        }
    }
}
