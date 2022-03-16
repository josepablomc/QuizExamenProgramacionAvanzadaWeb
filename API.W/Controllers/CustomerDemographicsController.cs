using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.W.Models;

namespace API.W.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDemographicsController : ControllerBase
    {
        private readonly Northwind2Context _context;

        public CustomerDemographicsController(Northwind2Context context)
        {
            _context = context;
        }

        // GET: api/CustomerDemographics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDemographics>>> GetCustomerDemographics()
        {
            return await _context.CustomerDemographics.ToListAsync();
        }

        // GET: api/CustomerDemographics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDemographics>> GetCustomerDemographics(string id)
        {
            var customerDemographics = await _context.CustomerDemographics.FindAsync(id);

            if (customerDemographics == null)
            {
                return NotFound();
            }

            return customerDemographics;
        }

        // PUT: api/CustomerDemographics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDemographics(string id, CustomerDemographics customerDemographics)
        {
            if (id != customerDemographics.CustomerTypeId)
            {
                return BadRequest();
            }

            _context.Entry(customerDemographics).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerDemographicsExists(id))
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


        [HttpPost]
        public async Task<ActionResult<CustomerDemographics>> PostCustomerDemographics(CustomerDemographics customerDemographics)
        {
            _context.CustomerDemographics.Add(customerDemographics);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CustomerDemographicsExists(customerDemographics.CustomerTypeId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCustomerDemographics", new { id = customerDemographics.CustomerTypeId }, customerDemographics);
        }

        // DELETE: api/CustomerDemographics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CustomerDemographics>> DeleteCustomerDemographics(string id)
        {
            var customerDemographics = await _context.CustomerDemographics.FindAsync(id);
            if (customerDemographics == null)
            {
                return NotFound();
            }

            _context.CustomerDemographics.Remove(customerDemographics);
            await _context.SaveChangesAsync();

            return customerDemographics;
        }

        private bool CustomerDemographicsExists(string id)
        {
            return _context.CustomerDemographics.Any(e => e.CustomerTypeId == id);
        }
    }
}
