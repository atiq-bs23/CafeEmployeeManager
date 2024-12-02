using CafeEmployeeManager.Application.DTOs;

namespace CafeEmployeeManager.Application.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeByIdAsync(Guid employeeId);
        Task<Guid> CreateEmployeeAsync(EmployeeDto employeeDto);
        Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto employeeDto);
        Task DeleteEmployeeAsync(Guid employeeId);
        Task<IEnumerable<EmployeeDto>> GetEmployeesByCafeAsync(Guid cafeId);
        Task AssignEmployeeToCafeAsync(Guid employeeId, Guid cafeId);
    }
}
