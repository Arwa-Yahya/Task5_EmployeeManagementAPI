
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Application.Employees;

namespace Products.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ISender _sender;

        public EmployeesController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var employees = await _sender.Send(new GetAllEmployeesQuery(), cancellationToken);

            return Ok(employees);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            var employee = await _sender.Send(new GetEmployeeByIdQuery(id), cancellationToken);

            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeCommand command, CancellationToken cancellationToken)
        {
            if (id != command.Id)
                return BadRequest("The route ID does not match the employee ID.");

            var employee = await _sender.Send(command, cancellationToken);

            if (employee is null)
                return NotFound();

            return Ok(employee);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        {
            var deleted = await _sender.Send(new DeleteEmployeeCommand(id), cancellationToken);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
