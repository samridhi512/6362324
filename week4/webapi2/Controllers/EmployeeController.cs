using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static List<string> employees = new List<string> { "John", "Jane", "Mark" };

       
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(employees);
        }

        
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= employees.Count)
                return NotFound("Employee not found");

            return Ok(employees[id]);
        }

       
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post([FromBody] string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Name cannot be empty");

            employees.Add(name);
            return CreatedAtAction(nameof(Get), new { id = employees.Count - 1 }, name);
        }

        
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult Put(int id, [FromBody] string name)
        {
            if (id < 0 || id >= employees.Count)
                return NotFound("Employee not found");

            employees[id] = name;
            return Ok("Updated");
        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= employees.Count)
                return NotFound("Employee not found");

            employees.RemoveAt(id);
            return Ok("Deleted");
        }
    }
}
