using CafeEmployeeManager.Application.DTOs;
using CafeEmployeeManager.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CafeEmployeeManager.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CafeController : ControllerBase
{
    private readonly ICafeService _cafeService;

    public CafeController(ICafeService cafeService)
    {
        _cafeService = cafeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCafes([FromQuery] string location)
    {
        var cafes = string.IsNullOrEmpty(location)
            ? await _cafeService.GetAllCafesAsync()
            : await _cafeService.GetCafesByLocationAsync(location);

        return Ok(cafes);
    }

    [HttpPost]
    public async Task<IActionResult> AddCafe([FromBody] CafeDto cafe)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var id = await _cafeService.CreateCafeAsync(cafe);
        return Ok(id);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCafe([FromBody] CafeDto cafe)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedCafe = await _cafeService.UpdateCafeAsync(cafe);
        if (updatedCafe == null)
        {
            return NotFound("Cafe not found.");
        }

        return NoContent(); 
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCafe(Guid id)
    {
        var cafe = await _cafeService.GetCafeByIdAsync(id);
        if (cafe == null)
        {
            return NotFound("Cafe not found.");
        }

        await _cafeService.DeleteCafeAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetCafeById(Guid id)
    {
        var cafe = await _cafeService.GetCafeByIdAsync(id);
        if (cafe == null)
        {
            return NotFound("Cafe not found.");
        }

        return Ok(cafe);
    }
}
