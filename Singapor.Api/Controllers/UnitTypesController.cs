﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Singapor.Services.Abstract;
using Singapor.Services.Models;

namespace Singapor.Api.Controllers
{
    public class UnitTypesController : ControllerBase<IUnitTypeService,UnitTypeModel>
    {
        public UnitTypesController(IUnitTypeService service)
            : base(service)
        {
        }

        [Authorize]
        public HttpResponseMessage Get()
        {
            return GetResponse(_service.Get(), HttpStatusCode.OK);
        }

        [Authorize]
        public HttpResponseMessage Get(Guid id)
        {
            return GetResponse(_service.Get(id), HttpStatusCode.Found);
        }

        [Authorize]
        public HttpResponseMessage Post(UnitTypeModel model)
        {
            return GetResponse(_service.Create(model), HttpStatusCode.Created);
        }
    }
}
