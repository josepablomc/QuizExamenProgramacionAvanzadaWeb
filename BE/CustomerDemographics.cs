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


    public class CustomerDemographics : ICRUD<data.CustomerDemographics>
    {
        private dal.CustomerDemographics _dal;
        public CustomerDemographics(NDbContext dbContext)
        {
            _dal = new dal.CustomerDemographics(dbContext);
        }
        public void Delete(data.CustomerDemographics t)
        {
            _dal.Delete(t);
        }

        public IEnumerable<data.CustomerDemographics> GetAll()
        {
            return _dal.GetAll();
        }

        public Task<IEnumerable<data.CustomerDemographics>> GetAllAsync()
        {
            return _dal.GetAllAsync();
        }

        public data.CustomerDemographics GetOneById(string id)
        {
            return _dal.GetOneById(id);
        }

        public Task<data.CustomerDemographics> GetOneByIdAsync(string id)
        {
            return _dal.GetOneByIdAsync(id);
        }

        public void Insert(data.CustomerDemographics t)
        {
            _dal.Insert(t);
        }

        public void Update(data.CustomerDemographics t)
        {
            _dal.Update(t);
        }
    }
}

