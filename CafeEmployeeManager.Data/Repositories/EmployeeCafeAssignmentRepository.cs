using CafeEmployeeManager.Core.Entities;
using CafeEmployeeManager.Data.Context;
using CafeEmployeeManager.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;


namespace CafeEmployeeManager.Data.Repositories
{
    public class EmployeeCafeAssignmentRepository : Repository<EmployeeCafeAssignment>, IEmployeeCafeAssignmentRepository
    {
        public EmployeeCafeAssignmentRepository(CafeEmployeeDbContext context) : base(context) { }

        public async Task<IEnumerable<EmployeeCafeAssignment>> GetCafesByEmployeeIdAsync(Guid employeeId)
        {
            return await _dbSet.Where(x => x.EmployeeId == employeeId)
                               .Include(x => x.Cafe)
                               .ToListAsync();
        }

        public async Task<IEnumerable<EmployeeCafeAssignment>> GetEmployeesAssignedToCafeAsync(Guid cafeId)
        {
            return await _dbSet.Where(x => x.CafeId == cafeId)
                               .Include(x => x.Employee)
                               .ToListAsync();
        }
    }
}
