
using Products.Domain.Entities;

namespace Products.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken);

        Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken);

        Task AddAsync(Employee employee, CancellationToken cancellationToken);

        Task UpdateAsync(Employee employee, CancellationToken cancellationToken);

        Task DeleteAsync(Employee employee, CancellationToken cancellationToken);
    }
}
