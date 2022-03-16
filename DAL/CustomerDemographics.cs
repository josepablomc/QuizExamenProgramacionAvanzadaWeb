using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using data = DAL.DO.Objects;


namespace DAL
{
    public class CustomerDemographics : ICRUD<data.CustomerDemographics>
    {
        private Repository<data.CustomerDemographics> repo;
        public CustomerDemographics(NDbContext dBContext)
        {
            repo = new Repository<data.CustomerDemographics>(dBContext);
        }

        public void Delete(data.CustomerDemographics t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.CustomerDemographics> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.CustomerDemographics>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.CustomerDemographics GetOneById(string id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.CustomerDemographics> GetOneByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.CustomerDemographics t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.CustomerDemographics t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
