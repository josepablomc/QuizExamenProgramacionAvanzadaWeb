using AutoMapper;
using DAL.DO.Objects;
using DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DAL.DO.Objects;
using models = API.DataModels;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerCustomerDemoController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public CustomerCustomerDemoController (NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/CustomerCustomerDemo
        [HttpGet]

        public async Task<ActionResult<IEnumerable<models.CustomerCustomerDemo>>> GetCustomerCustomerDemo()
        {

            var res = new BE.CustomerCustomerDemo(_context).GetAll();
            List<models.CustomerCustomerDemo> mapaAux = _mapper.Map<IEnumerable<data.CustomerCustomerDemo>, IEnumerable<models.CustomerCustomerDemo>>(res).ToList();
            return mapaAux;
        }


        // GET: api/CustomerCustomerDemo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.CustomerCustomerDemo>> GetCustomerCustomerDemo(string id)
        {
            var customerCustomerDemo = new BE.CustomerCustomerDemo(_context).GetOneById(id);

            if (customerCustomerDemo == null)
            {
                return NotFound();
            }
            models.CustomerCustomerDemo mapaAux = _mapper.Map<data.CustomerCustomerDemo, models.CustomerCustomerDemo>(customerCustomerDemo);
            return mapaAux;

        }

        // PUT: api/CustomerCustomerDemo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerCustomerDemo(string id, models.CustomerCustomerDemo CustomerCustomerDemo)
        {
            if (id != CustomerCustomerDemo.CustomerId)
            {
                return BadRequest();
            }


            try
            {
                data.CustomerCustomerDemo mapaAux = _mapper.Map<models.CustomerCustomerDemo, data.CustomerCustomerDemo>(CustomerCustomerDemo);
                //return mapaAux;
                new BE.CustomerCustomerDemo(_context).Update(mapaAux);

            }
            catch (Exception ee)
            {
                if (!Exists(id))
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
        public async Task<ActionResult<models.CustomerCustomerDemo>> PostCustomerCustomerDemo(models.CustomerCustomerDemo customerCustomerDemo)
        {
            try
            {
                data.CustomerCustomerDemo mapaAux = _mapper.Map<models.CustomerCustomerDemo, data.CustomerCustomerDemo>(customerCustomerDemo);
                new BE.CustomerCustomerDemo(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }


            return CreatedAtAction("GetCustomers", new { id = customerCustomerDemo.CustomerId }, customerCustomerDemo);
        }

        // DELETE: api/CustomerCustomerDemo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.CustomerCustomerDemo>> DeleteCustomerCustomerDemo(string id)
        {
            var customerCustomerDemo = new BE.CustomerCustomerDemo(_context).GetOneById(id);
            if (customerCustomerDemo == null)
            {
                return NotFound();
            }

            try
            {
                new BE.CustomerCustomerDemo(_context).Delete(customerCustomerDemo);
            }
            catch (Exception)
            {

                BadRequest();
            }

            models.CustomerCustomerDemo mapaAux = _mapper.Map<data.CustomerCustomerDemo, models.CustomerCustomerDemo>(customerCustomerDemo);
            return mapaAux;
        }

        private bool Exists(string id)
        {
            return (new BE.CustomerCustomerDemo(_context).GetOneById(id) != null);
        }
    }
}