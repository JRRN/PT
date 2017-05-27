using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Web.Http;
using AutoMapper;
using CustomAuthorization;

namespace BackEnd.Controllers.Base
{
    public class BaseController : ApiController
    {
        protected readonly IMapper _mapper;
        protected readonly IAuthorization _authorization;

        public BaseController(IMapper mapper, IAuthorization authorization)
        {
            _mapper = mapper;
            _authorization = authorization;
        }


    }
}
