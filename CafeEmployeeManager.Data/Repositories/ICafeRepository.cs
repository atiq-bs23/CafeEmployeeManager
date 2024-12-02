using CafeEmployeeManager.Core.Entities;
using CafeEmployeeManager.Data.Repositories.Base;

namespace CafeEmployeeManager.Data.Repositories
{
    public interface ICafeRepository : IRepository<Cafe>
    {
        Task<IEnumerable<Cafe>> GetCafeesbyLocationAsync(string location);
    }
}
