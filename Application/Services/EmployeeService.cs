using AutoMapper;
using CafeEmployeeManager.Application.DTOs;
using CafeEmployeeManager.Application.Services.Interfaces;
using CafeEmployeeManager.Core.Entities;
using CafeEmployeeManager.Data.Repositories;

namespace CafeEmployeeManager.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeCafeAssignmentRepository _assignmentRepository;
        private readonly ICafeRepository _cafeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, 
            IEmployeeCafeAssignmentRepository assignmentRepository,ICafeRepository cafeRepository,
            IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _assignmentRepository = assignmentRepository;
            _cafeRepository = cafeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(Guid employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<Guid> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.AddAsync(employee);
            return employee.Id;
        }

        public async Task<EmployeeDto> UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _employeeRepository.UpdateAsync(employee);
            return employeeDto;
        }

        public async Task DeleteEmployeeAsync(Guid employeeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee != null)
            {
                await _employeeRepository.DeleteAsync(employee);
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesByCafeAsync(Guid cafeId)
        {
            var assignments = await _assignmentRepository.GetAllAsync();
            var employees = assignments
                .Where(a => a.CafeId == cafeId)
                .Select(a => a.Employee);

            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task AssignEmployeeToCafeAsync(Guid employeeId, Guid cafeId)
        {
            var employee = await _employeeRepository.GetByIdAsync(employeeId);
            if (employee == null) throw new KeyNotFoundException("Employee not found.");

            var cafe = await _assignmentRepository.GetByIdAsync(cafeId);
            if (cafe == null) throw new KeyNotFoundException("Cafe not found.");

            var assignment = new EmployeeCafeAssignment
            {
                EmployeeId = employeeId,
                CafeId = cafeId
            };

            await _assignmentRepository.AddAsync(assignment);

        }
    }
}
