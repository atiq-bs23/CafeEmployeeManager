using CafeEmployeeManager.Application.DTOs;

namespace CafeEmployeeManager.Application.Services.Interfaces
{
    public interface ICafeService
    {
        Task<IEnumerable<CafeDto>> GetAllCafesAsync();
        Task<CafeDto> GetCafeByIdAsync(Guid cafeId);
        Task<IEnumerable<CafeDto>> GetCafesByLocationAsync(string location);
        Task<Guid> CreateCafeAsync(CafeDto cafe);
        Task<CafeDto> UpdateCafeAsync(CafeDto cafeDto);
        Task DeleteCafeAsync(Guid cafeId);
        Task<IEnumerable<EmployeeDto>> GetEmployeesForCafeAsync(Guid cafeId);
    }
}
