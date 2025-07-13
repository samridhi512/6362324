using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // Simulated database
        private static List<string> values = new List<string> { "Value1", "Value2" };

        // GET: api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(values);
        }

        // GET: api/values/1
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("Item not found");

            return Ok(values[id]);
        }

        // POST: api/values
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            if (string.IsNullOrEmpty(value))
                return BadRequest("Value cannot be empty");

            values.Add(value);
            return CreatedAtAction(nameof(Get), new { id = values.Count - 1 }, value);
        }

        // PUT: api/values/1
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("Item not found");

            values[id] = value;
            return Ok("Updated successfully");
        }

        // DELETE: api/values/1
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
                return NotFound("Item not found");

            values.RemoveAt(id);
            return Ok("Deleted successfully");
        }
    }
}
