using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Singapor.Model.Entities;

namespace Singapor.Services.Models.Maps
{
    public class ProjectMapper : IMapConfiguration
    {
        public void Map()
        {
            Mapper.CreateMap<ProjectModel, Project>();
            Mapper.CreateMap<Project, ProjectModel>();
        }
    }
}
