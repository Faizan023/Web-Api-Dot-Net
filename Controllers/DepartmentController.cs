using DataService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;

namespace Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _department;

        public DepartmentController(IDepartment department)
        {
            _department = department ?? throw new ArgumentNullException(nameof(department));
        }

        [HttpGet]
        [Route("GetDepartment")]
        public async Task<IActionResult> get()
        {
            return Ok(await _department.GetDepartments());
        }

        [HttpGet]
        [Route("GetDepartmentById")]
        public async Task<IActionResult> GetById(int Id)
        {
            return Ok(await _department.GetDepartmentById(Id));
        }

        [HttpPost]
        [Route("InsertDepartment")]
        public async Task<IActionResult> Post(Department dep)
        {
            var result = await _department.InsertDepartment(dep);
            if (result.DepartmentId == 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Something Went Wrong");
            }
            return Ok("Added Successfully");
        }

        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> Put(Department dep)
        {
            await _department.UpdateDepartment(dep);
            return Ok("Updated Successfully");
        }

        [HttpDelete]
        [Route("DeleteDepartment")]
        public JsonResult Delete(int Id)
        {
            var result = _department.DeleteDepartment(Id);
            return new JsonResult("Deleted Successfully");
        }
    }
}
