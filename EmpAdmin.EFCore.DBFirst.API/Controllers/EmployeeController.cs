using EmpAdmin.EFCore.DBFirst.API.Interface;
using EmpAdmin.EFCore.DBFirst.API.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace EmpAdmin.EFCore.DBFirst.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            return Ok(await _employeeService.GetAllEmployeeAsync());
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(AddEditEmployeeDto employeeDto)
        {
            return Ok(await _employeeService.CreateEmployeeAsync(employeeDto));
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> EmployeeById(Guid id)
        {
            return Ok(await _employeeService.GetEmployeeByIdAsync(id));
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateEmployeeById(Guid id, AddEditEmployeeDto employeeDto)
        {
            return Ok(await _employeeService.UpdateEmployeeAsync(id, employeeDto));
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeById(Guid id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return Ok();
        }
    }
}
