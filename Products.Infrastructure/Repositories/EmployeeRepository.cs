
using Microsoft.EntityFrameworkCore;
using Products.Application.Interfaces;
using Products.Domain.Entities;
using Products.Infrastructure.Persistence;

namespace Products.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ProductsDbContext _context;

        public EmployeeRepository(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Employee>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Employees
                .AsNoTracking()
                .OrderBy(employee => employee.Id)
                .ToListAsync(cancellationToken);
        }

        public async Task<Employee?> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .AsNoTracking()
                .FirstOrDefaultAsync(employee => employee.Id == id, cancellationToken);
        }

        public async Task AddAsync(Employee employee, CancellationToken cancellationToken)
        {
            await _context.Employees.AddAsync(employee, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Employee employee, CancellationToken cancellationToken)
        {
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
