﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Singapor.DAL;
using Singapor.DAL.Repositories;
using Singapor.Model.Entities;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Services.Services
{
    public class ProjectService : BaseService<ProjectModel, Project>, IProjectService
    {
        public ProjectService(
            IUnitOfWork unitOfWork, 
            ITranslationsService translationsService, 
            IRepository<Project> repository) : base(unitOfWork, translationsService, repository)
        {
        }
    }
}
