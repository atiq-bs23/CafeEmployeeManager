using CafeEmployeeManager.Application.DTOs;
using CafeEmployeeManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CafeEmployeeManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees([FromQuery] Guid cafe)
    {
        var employees = await _employeeService.GetEmployeesByCafeAsync(cafe);
        return Ok(employees);
    }

    [HttpPost]
    public async Task<IActionResult> AddEmployee([FromBody] EmployeeDto employeeDto)
    {
        var id = await _employeeService.CreateEmployeeAsync(employeeDto);
        return CreatedAtAction(nameof(GetEmployees), new { id = id });
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromBody] EmployeeDto employeeDto)
    {
        await _employeeService.UpdateEmployeeAsync(employeeDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(Guid id)
    {
        await _employeeService.DeleteEmployeeAsync(id);
        return NoContent();
    }

    [HttpPost("{employeeId}/assign/{cafeId}")]
    public async Task<IActionResult> AssignEmployeeToCafe(Guid employeeId, Guid cafeId)
    {
        await _employeeService.AssignEmployeeToCafeAsync(employeeId, cafeId);
        return NoContent();
    }
}
