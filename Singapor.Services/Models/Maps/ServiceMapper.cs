using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Singapor.Model.Entities;

namespace Singapor.Services.Models.Maps
{
    public class ServiceMapper : IMapConfiguration
    {
        public void Map()
        {
            Mapper.CreateMap<ServiceModel, Service>();
            Mapper.CreateMap<Service, ServiceModel>();
        }
    }
}
