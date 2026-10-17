
using MediatR;
using Products.Application.Interfaces;

namespace Products.Application.Employees
{
    public sealed record DeleteEmployeeCommand(int Id) : IRequest<bool>;

    public sealed class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (employee is null)
                return false;

            await _employeeRepository.DeleteAsync(employee, cancellationToken);

            return true;
        }
    }
}
