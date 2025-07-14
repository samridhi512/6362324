using Microsoft.AspNetCore.Mvc;
using EmployeeCrudApi.Models;
using EmployeeCrudApi.Services;
using System.ComponentModel.DataAnnotations;
namespace EmployeeCrudApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>List of all employees</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), 200)]
        public ActionResult<List<Employee>> GetEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }
        /// <summary>
        /// Get employee by ID
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Employee data</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Employee), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public ActionResult<Employee> GetEmployee(int id)
        {
            // Check if the id value is lesser than or equal to 0
            if (id <= 0)
            {
                return BadRequest(new ErrorResponse { Error = "Invalid employee id" });
            }
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return BadRequest(new ErrorResponse { Error = "Invalid employee id" });
            }
            return Ok(employee);
        }
        /// <summary>
        /// Create new employee
        /// </summary>
        /// <param name="employee">Employee data from request body (FromBody attribute)</param>
        /// <returns>Created employee data</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Employee), 201)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public ActionResult<Employee> CreateEmployee([FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ErrorResponse
                {
                    Error = "Invalid employee data"
                });
            }
            try
            {
                var createdEmployee = _employeeService.CreateEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee), new
                {
                    id = createdEmployee.Id
                }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse
                {
                    Error = $"Internal server error: {ex.Message}"
                });
            }
        }
        /// <summary>
        /// Update employee data using PUT action method with validation
        /// Uses FromBody attribute to extract JSON data from request body
        /// Validates employee ID (must be > 0 and exist in hardcoded list)
        /// Returns updated employee data through ActionResult
        /// </summary>
        /// <param name="id">The ID of the employee to update</param>
        /// <param name="updateRequest">Employee data to update (FromBody 
        /// attribute)</ param >
        /// <returns>Updated employee data or error response</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<Employee>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        [ProducesResponseType(typeof(ErrorResponse), 500)]
    public ActionResult<ApiResponse<Employee>> UpdateEmployee(int id, [FromBody] EmployeeUpdateRequest updateRequest)
        {
            try
            {
                // Check if the id value is lesser than or equal to 0
                if (id <= 0)
                {
                    return BadRequest(new ErrorResponse
                    {
                        Error = "Invalid employee  id" });
                    }
                    // Check if the id exists in the hardcoded list of employees
                    var existingEmployee = _employeeService.GetEmployeeById(id);
                    if (existingEmployee == null)
                    {
                        return BadRequest(new ErrorResponse
                        {
                            Error = "Invalid employee id" });
                        }
                    // Extract data from request body using FromBody attribute
if (updateRequest == null)
                        {
                            return BadRequest(new ErrorResponse
                            {
                                Error = "No data provided in request body" });
                            }
// Validate the model state
if (!ModelState.IsValid)
                            {
                                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e =>
                                e.ErrorMessage);
                                return BadRequest(new ErrorResponse
                                {
                                    Error = $"Validation errors: {string.Join(", ", errors)}"
                                });
                                }
                                // Update the employee with the JSON data from input body
                                var updatedEmployee = _employeeService.UpdateEmployee(id, updateRequest);
                                if (updatedEmployee == null)
                                {
                                    return StatusCode(500, new ErrorResponse
                                    {
                                        Error = "Failed to update employee" });
                                    }
                                // Filter the employee list data for the input id and return that as output
return Ok(new ApiResponse<Employee>
{
    Message = "Employee updated successfully",
    Data = updatedEmployee,
    Success = true
});
}
catch (Exception ex)
            {
                return StatusCode(500, new ErrorResponse
                {
                    Error = $"Internal server  error: { ex.Message}" });
}
        }
        /// <summary>
        /// Delete employee by ID
        /// </summary>
        /// <param name="id">Employee ID</param>
        /// <returns>Success or error response</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<object>), 200)]
        [ProducesResponseType(typeof(ErrorResponse), 400)]
        public ActionResult DeleteEmployee(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new ErrorResponse { Error = "Invalid employee id" });
            }
            var deleted = _employeeService.DeleteEmployee(id);
            if (!deleted)
            {
                return BadRequest(new ErrorResponse { Error = "Invalid employee id" });
            }
            return Ok(new ApiResponse<object>
            {
                Message = "Employee deleted successfully",
                Success = true
            });
        }
        /// <summary>
        /// Get all valid employee IDs for testing purposes
        /// </summary>
        /// <returns>List of valid employee IDs</returns>
        [HttpGet("ids")]
        [ProducesResponseType(typeof(object), 200)]
        public ActionResult GetEmployeeIds()
        {
            var ids = _employeeService.GetValidEmployeeIds();
            return Ok(new
            {
                ValidEmployeeIds = ids,
                TotalEmployees = ids.Count
            });
        }
    }
}