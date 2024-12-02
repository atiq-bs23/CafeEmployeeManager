using CafeEmployeeManager.Core.Entities;
using CafeEmployeeManager.Data.Repositories.Base;

namespace CafeEmployeeManager.Data.Repositories
{
    public interface IEmployeeCafeAssignmentRepository : IRepository<EmployeeCafeAssignment>
    {
        Task<IEnumerable<EmployeeCafeAssignment>> GetCafesByEmployeeIdAsync(Guid employeeId);
        Task<IEnumerable<EmployeeCafeAssignment>> GetEmployeesAssignedToCafeAsync(Guid cafeId);

    }
}
