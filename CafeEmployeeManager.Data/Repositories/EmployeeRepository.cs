using CafeEmployeeManager.Core.Entities;
using CafeEmployeeManager.Data.Context;
using CafeEmployeeManager.Data.Repositories.Base;

namespace CafeEmployeeManager.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly CafeEmployeeDbContext _context;

        public EmployeeRepository(CafeEmployeeDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
