using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using data = DAL.DO.Objects;

namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<data.CustomerCustomerDemo, DataModels.CustomerCustomerDemo>().ReverseMap();
            CreateMap<data.CustomerDemographics, DataModels.CustomerDemographics>().ReverseMap();
            CreateMap<data.Customers, DataModels.Customers>().ReverseMap();



        }
    }
}
