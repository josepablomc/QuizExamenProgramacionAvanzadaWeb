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
    public class CustomerDemographicsController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;

        public CustomerDemographicsController(NDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // GET: api/CustomerDemographics
        [HttpGet]

        public async Task<ActionResult<IEnumerable<models.CustomerDemographics>>> GetCustomerDemographics()
        {

            var res = new BE.CustomerDemographics(_context).GetAll();
            List<models.CustomerDemographics> mapaAux = _mapper.Map<IEnumerable<data.CustomerDemographics>, IEnumerable<models.CustomerDemographics>>(res).ToList();
            return mapaAux;
        }


        // GET: api/CustomerDemographics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.CustomerDemographics>> GetCustomerDemographics(string id)
        {
            var customerDemographics = new BE.CustomerDemographics(_context).GetOneById(id);

            if (customerDemographics == null)
            {
                return NotFound();
            }
            models.CustomerDemographics mapaAux = _mapper.Map<data.CustomerDemographics, models.CustomerDemographics>(customerDemographics);
            return mapaAux;

        }

        // PUT: api/CustomerDemographics/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDemographics(string id, models.CustomerDemographics CustomerDemographics)
        {
            if (id != CustomerDemographics.CustomerTypeId)
            {
                return BadRequest();
            }


            try
            {
                data.CustomerDemographics mapaAux = _mapper.Map<models.CustomerDemographics, data.CustomerDemographics>(CustomerDemographics);
                //return mapaAux;
                new BE.CustomerDemographics(_context).Update(mapaAux);

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
        public async Task<ActionResult<models.CustomerDemographics>> PostCustomerDemographics(models.CustomerDemographics customerDemographics)
        {
            try
            {
                data.CustomerDemographics mapaAux = _mapper.Map<models.CustomerDemographics, data.CustomerDemographics>(customerDemographics);
                new BE.CustomerDemographics(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }


            return CreatedAtAction("GetCustomers", new { id = customerDemographics.CustomerTypeId }, customerDemographics);
        }

        // DELETE: api/CustomerDemographics/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.CustomerDemographics>> DeleteCustomerDemographics(string id)
        {
            var customerDemographics = new BE.CustomerDemographics(_context).GetOneById(id);
            if (customerDemographics == null)
            {
                return NotFound();
            }

            try
            {
                new BE.CustomerDemographics(_context).Delete(customerDemographics);
            }
            catch (Exception)
            {

                BadRequest();
            }

            models.CustomerDemographics mapaAux = _mapper.Map<data.CustomerDemographics, models.CustomerDemographics>(customerDemographics);
            return mapaAux;
        }

        private bool Exists(string id)
        {
            return (new BE.CustomerDemographics(_context).GetOneById(id) != null);
        }
    }
}