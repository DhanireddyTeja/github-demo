using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Employee.DataAccess;
using Employee.Models;
using Employee.Repository;

namespace Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeModelsController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeModelsController(IEmployeeRepository employeeRepository)
        {
            _employeeRepo = employeeRepository;
        }

        // GET: api/EmployeeModels
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _employeeRepo.GetType();
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] EmployeeModels employees)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _employeeRepo.Post(employees);
                    return StatusCode(200, result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }



        }

        [HttpPut("Put")]
        public async Task<IActionResult> put([FromBody] EmployeeModels employees)
        {
            try
            {
                var result = _employeeRepo.Put(employees);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete("Delete")]

        public async Task<IActionResult> Delete(int employeesId)
        {
            try
            {
                var result = _employeeRepo.Delete(employeesId);
                return StatusCode(200, result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }
    }
}

       /* // GET: api/EmployeeModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeModels>> GetEmployeeModels(int id)
        {
            var employeeModels = await _context.employee.FindAsync(id);

            if (employeeModels == null)
            {
                return NotFound();
            }

            return employeeModels;
        }

        // PUT: api/EmployeeModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeModels(int id, EmployeeModels employeeModels)
        {
            if (id != employeeModels.Id)
            {
                return BadRequest();
            }

            _context.Entry(employeeModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeModelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EmployeeModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EmployeeModels>> PostEmployeeModels(EmployeeModels employeeModels)
        {
            _context.employee.Add(employeeModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployeeModels", new { id = employeeModels.Id }, employeeModels);
        }

        // DELETE: api/EmployeeModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmployeeModels>> DeleteEmployeeModels(int id)
        {
            var employeeModels = await _context.employee.FindAsync(id);
            if (employeeModels == null)
            {
                return NotFound();
            }

            _context.employee.Remove(employeeModels);
            await _context.SaveChangesAsync();

            return employeeModels;
        }

        private bool EmployeeModelsExists(int id)
        {
            return _context.employee.Any(e => e.Id == id);
        }
    }
}*/
