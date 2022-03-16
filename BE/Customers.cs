using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using dal = DAL;
using DAL.DO.Interfaces;
using System.Threading.Tasks;
using DAL.EF;

namespace BE
{


    public class Customers : ICRUD<data.Customers>
    {
        private dal.Customers _dal;
        public Customers(NDbContext dbContext)
        {
            _dal = new dal.Customers(dbContext);
        }
        public void Delete(data.Customers t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.Customers> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.Customers>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.Customers GetOneById(string id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.Customers> GetOneByIdAsync(string id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.Customers t)
        {
            _dal.Insert(t);
        }

        public void Update(data.Customers t)
        {
            _dal.Update(t);
        }
    }
}

