using CafeEmployeeManager.Core.Entities;
using CafeEmployeeManager.Data.Context;
using CafeEmployeeManager.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CafeEmployeeManager.Data.Repositories
{
    public class CafeRepository : Repository<Cafe>, ICafeRepository
    {
        public CafeRepository(CafeEmployeeDbContext context) : base(context) { }

        public async Task<IEnumerable<Cafe>> GetCafeesbyLocationAsync(string location)
        {
            return await _dbSet.Where(x => x.Location.ToLower().Contains(location.ToLower())).ToListAsync();
        }
    }

}
