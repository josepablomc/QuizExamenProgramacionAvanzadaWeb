
using DAL.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{


    public class RepositoryCustomerCustomerDemo : Repository<data.CustomerCustomerDemo>, IRepositoryCustomerCustomerDemo
    {
        public RepositoryCustomerCustomerDemo(NDbContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<data.CustomerCustomerDemo>> GetAllAsync()
        {
            return await _db.CustomerCustomerDemo.Include(n => n.Customer).Include(m => m.CustomerType).ToListAsync();
        }

        public async Task<data.CustomerCustomerDemo> GetOneByIdAsync(string CustomerId, string CustomerTypeId)
        {
            return await _db.CustomerCustomerDemo.Include(n => n.Customer).Include(m => m.CustomerType).SingleOrDefaultAsync(n => n.CustomerId == CustomerId && n.CustomerTypeId == CustomerTypeId);
        }
        private NDbContext _db
        {
            get
            {
                return dbContext as NDbContext;
            }
        }
    }
}
