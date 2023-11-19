using EmployeeAPI.DTOs;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;

        }
        [HttpPost]
        public async ValueTask<IActionResult> CreateEmployeeAsync(EmployeeDto employeeDto)
        {
            var res = _employeeService.CreateEmployeeAsync(employeeDto);
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetAllAsync()
        {
            var res = await _employeeService.GetAllEmployeeAsync();
            return Ok(res);
        }
        [HttpGet]
        public async ValueTask<IActionResult> GetByIdAsync(int id)
        {
            var res = await _employeeService.GetByIdAsync(id);
            return Ok(res);
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteByIdAsync(int id)
        {
            var res = await _employeeService.DeleteByIdAsync(id);
            return Ok(res);
        }
        [HttpPut]
        public async ValueTask<IActionResult> UpdateEmployeeAsync(int id, EmployeeDto employeeDto)
        {
            var res = await _employeeService.UpdateEmployeeAsync(id, employeeDto);
            return Ok(res);
        }
    }
}
