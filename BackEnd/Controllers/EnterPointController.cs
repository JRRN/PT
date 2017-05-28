using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using Application.Services.Client;
using Application.Services.Polices;

using AutoMapper;
using BackEnd.Controllers.Base;
using CustomAuthorization;
using Domain.Model;
using Newtonsoft.Json;

namespace BackEnd.Controllers
{
    public class EnterPointController : BaseController
    {
        private readonly IClientApplication _clientApplication;
        private readonly IPoliceApplication _policeApplication;
       // private readonly IValidationRoles _validationRoles;

        // GET: api/Clients

        public EnterPointController(IMapper mapper, IAuthorization authorization, 
            IClientApplication clientApplication, IPoliceApplication policeApplication) 
            : base(mapper, authorization)
        {
            _clientApplication = clientApplication;
            _policeApplication = policeApplication;
        }

        [HttpGet]
        [ActionName("GetClientById")]
        [Authorize(Roles = "users, admin")]
        public HttpResponseMessage GetClientById(int id)
        {
            var client = _clientApplication.GetById(id);
            
            if (client == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Created, JsonConvert.SerializeObject(client));
        }

        [HttpGet]
        [ActionName("GetClientByUserName")]
        [Authorize(Roles = "users, admin")]
        public HttpResponseMessage GetClientByUserName(string clientName)
        {
            var policeEntity = _clientApplication.FindByName(clientName);
            if (policeEntity == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Created, JsonConvert.SerializeObject(policeEntity));
        }

        [HttpGet]
        [ActionName("GetPolicesByClient")]
        [Authorize(Roles = "admin")]
        public HttpResponseMessage GetPolicesByClient(string userName)
        {
            var idClient = _clientApplication.FindByName(userName).ObjectId;
            var policeEntity = _policeApplication.GetAllPolices().Where(police => police.clientId.Equals(idClient));
            if (!policeEntity.Any())
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Created, JsonConvert.SerializeObject(policeEntity));
        }

        [HttpGet]
        [ActionName("GetLinked")]
        [Authorize(Roles = "admin")]
        public HttpResponseMessage GetLinked(string policeNumber)
        {
            var policeClient = _policeApplication.GetAllPolices().FirstOrDefault(police => police.Id.Equals(policeNumber));
            var clientPoliceAssociated = _clientApplication.GetById(policeClient.Id);
            if (clientPoliceAssociated == null) { 
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Created, JsonConvert.SerializeObject(clientPoliceAssociated));
        }
    }
}
