using DataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employee;

        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee ?? throw new ArgumentNullException(nameof(employee));
        }

        [HttpGet]
        [Route("GetEmployee")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _employee.GetEmployees());
        }

        [HttpGet]
        [Route("GetEmployeeById")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _employee.GetEmployeeById(Id));
        }

        [HttpPost]
        [Route("InsertEmployee")]
        public async Task<IActionResult> Post(Employee employee)
        {
            var result = await _employee.InsertEmployee(employee);
            if (result.EmployeeId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Addes SuccessFully");
        }

        [HttpPut]
        [Route("UpdateEmployee")]
        public async Task<IActionResult> Put(Employee employee)
        {
            await _employee.UpdateEmployee(employee);
            return Ok("Updated SuccessFully");
        }

        [HttpDelete]
        [Route("DeleteEmployee")]
        public JsonResult Delete(int Id)
        {
            _employee.DeleteEmployee(Id);
            return new JsonResult("Delete SuccessFully");
        }
    }
}
