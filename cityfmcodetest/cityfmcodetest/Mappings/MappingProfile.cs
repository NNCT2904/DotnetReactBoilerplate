using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using cityfmcodetest.Models;
using cityfmcodetest.Models.Dto;

namespace cityfmcodetest.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, FetchProductDto>();
            CreateMap<Product, GetProductDto>();
        }
    }
}
