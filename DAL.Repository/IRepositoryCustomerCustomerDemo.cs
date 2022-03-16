using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = DAL.DO.Objects;

namespace DAL.Repository
{

    public interface IRepositoryCustomerCustomerDemo : IRepository<data.CustomerCustomerDemo>
    {
        Task<IEnumerable<data.CustomerCustomerDemo>> GetAllAsync();
        Task<data.CustomerCustomerDemo> GetOneByIdAsync(string CustomerId, string CustomerTypeId);
    }
}
