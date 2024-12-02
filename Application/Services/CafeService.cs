using AutoMapper;
using CafeEmployeeManager.Application.DTOs;
using CafeEmployeeManager.Application.Services.Interfaces;
using CafeEmployeeManager.Core.Entities;
using CafeEmployeeManager.Data.Repositories;

namespace CafeEmployeeManager.Application.Services
{
    public class CafeService : ICafeService
    {
        private readonly ICafeRepository _cafeRepository;
        private readonly IEmployeeCafeAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public CafeService(ICafeRepository cafeRepository,
                           IEmployeeCafeAssignmentRepository assignmentRepository,
                           IMapper mapper)
        {
            _cafeRepository = cafeRepository;
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CafeDto>> GetAllCafesAsync()
        {
            var cafes = await _cafeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CafeDto>>(cafes);
        }

        public async Task<CafeDto> GetCafeByIdAsync(Guid cafeId)
        {
            var cafe = await _cafeRepository.GetByIdAsync(cafeId);
            return _mapper.Map<CafeDto>(cafe);
        }

        public async Task<Guid> CreateCafeAsync(CafeDto cafeDto)
        {
            var cafe = _mapper.Map<Cafe>(cafeDto);
            await _cafeRepository.AddAsync(cafe);
            return cafe.Id;
        }

        public async Task<CafeDto> UpdateCafeAsync(CafeDto cafeDto)
        {
            var cafe = _mapper.Map<Cafe>(cafeDto);
            await _cafeRepository.UpdateAsync(cafe);
            return cafeDto;
        }

        public async Task DeleteCafeAsync(Guid cafeId)
        {
            var cafe = await _cafeRepository.GetByIdAsync(cafeId);
            if (cafe != null)
            {
                await _cafeRepository.DeleteAsync(cafe);
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployeesForCafeAsync(Guid cafeId)
        {
            var assignments = await _assignmentRepository.GetEmployeesAssignedToCafeAsync(cafeId);
            var employees = assignments.Select(x => x.Employee);
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task<IEnumerable<CafeDto>> GetCafesByLocationAsync(string location)
        {
            var cafes = await _cafeRepository.GetCafeesbyLocationAsync(location);
            return _mapper.Map<IEnumerable<CafeDto>>(cafes);
        }
    }
}
