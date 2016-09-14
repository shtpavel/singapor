using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using Singapor.Common.Contexts;
using Singapor.Services.Abstract;
using Singapor.Services.Models;
using Singapor.Services.Responses;

namespace Singapor.Api.Controllers.CRUD
{
    [RoutePrefix(Settings.FullApiPrefix + "projects")]
    public class ProjectController : BaseController
    {
        private readonly IProjectService _projectService;
        public ProjectController(
            IUserContext userContext, 
            IProjectService projectService) : base(userContext)
        {
            _projectService = projectService;
        }

        [HttpGet, Route("")]
        public ListEntityResponse<ProjectModel> GetAll()
        {
            return _projectService.Get();
        }

        [HttpPost, Route("")]
        public SingleEntityResponse<ProjectModel> Create([FromBody]ProjectModel project)
        {
            return _projectService.Create(project);
        }

        [HttpPut, Route("")]
        public SingleEntityResponse<ProjectModel> Update([FromBody]ProjectModel project)
        {
            return _projectService.Update(project);
        }

        [HttpGet, Route("{projectId:Guid}")]
        public SingleEntityResponse<ProjectModel> GetById(Guid projectId)
        {
            return _projectService.Get(projectId);
        }

        [HttpDelete, Route("{projectId:Guid}")]
        public EmptyResponse DeleteById(Guid projectId)
        {
            return _projectService.Delete(projectId);
        }
    }
}
