using Accelist.MongoDBDemo.API.Models;
using Accelist.MongoDBDemo.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Accelist.MongoDBDemo.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly EmployeeService employeeService;

    public EmployeeController(EmployeeService employeeService) =>
        this.employeeService = employeeService;

    [HttpGet]
    public async Task<List<Employee>> Get() =>
        await employeeService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Employee>> Get(string id)
    {
        var employee = await employeeService.GetAsync(id);

        if (employee is null)
        {
            return NotFound();
        }

        return employee;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Employee newEmployee)
    {
        await employeeService.CreateAsync(newEmployee);

        return CreatedAtAction(nameof(Get), new { id = newEmployee.Id }, newEmployee);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, Employee updatedEmployee)
    {
        var employee = await employeeService.GetAsync(id);

        if (employee is null)
        {
            return NotFound();
        }

        updatedEmployee.Id = employee.Id;

        await employeeService.UpdateAsync(id, updatedEmployee);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var employee = await employeeService.GetAsync(id);

        if (employee is null)
        {
            return NotFound();
        }

        await employeeService.RemoveAsync(id);

        return NoContent();
    }
}
