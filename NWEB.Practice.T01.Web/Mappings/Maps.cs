using AutoMapper;
using NWEB.Practice.T01.Web.Data;
using NWEB.Practice.T01.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NWEB.Practice.T01.Web.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<Category, CategoryVM>().ReverseMap();
            CreateMap<Flower, FlowerVM>().ReverseMap();
        }
    }
}
