using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Application.Services.ClientWrapper;
using Application.Services.Polices;
using Application.Services.PolicesWrapper;
using AutoMapper;
using BackEnd.Controllers.Base;
using CustomAuthorization;
using Domain.Model;
using Newtonsoft.Json;

namespace BackEnd.Controllers
{
    public class WrapperController : BaseController
    {
        private readonly IClientWrapperApplication _clientApplication;
        private readonly IPoliceWrapperApplication _policeApplication;
        public WrapperController(IMapper mapper, IAuthorization authorization, IPoliceWrapperApplication policeApplication, IClientWrapperApplication clientApplication) : base(mapper, authorization)
        {
            _policeApplication = policeApplication;
            _clientApplication = clientApplication;
        }
        [HttpGet]
        [ActionName("GetClientById")]
        //[Authorize(Roles = "users, admin")]
        public HttpResponseMessage GetClientById(string id)
        {
            var clients = _clientApplication.GetAllClientsWrapper();

            var client = clients.Clients.FirstOrDefault(clientById => clientById.id.Equals(id));

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
            var clients = _clientApplication.GetAllClientsWrapper();
            var client = clients.Clients.FirstOrDefault(clientByName => clientByName.name.Equals(clientName));
            if (client == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.Created, JsonConvert.SerializeObject(client));
        }

        [HttpGet]
        [ActionName("GetPolicesByClient")]
        [Authorize(Roles = "admin")]
        public HttpResponseMessage GetPolicesByClient(string userName)
        {
            var clients = _clientApplication.GetAllClientsWrapper();
            var firstOrDefault = clients.Clients.FirstOrDefault(clientByName => clientByName.name.Equals(userName));
            if (firstOrDefault != null)
            {
                var clientId = firstOrDefault.id;

                var policies = _policeApplication.GetAllPolicesWrapper();

                var policeEntity = policies.Policies.Where(policiesByUser => policiesByUser.clientId.Equals(clientId));
                if (!policeEntity.Any())
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.Created, JsonConvert.SerializeObject(policeEntity));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }

        [HttpGet]
        [ActionName("GetLinked")]
        [Authorize(Roles = "admin")]
        public HttpResponseMessage GetLinked(string policeNumber)
        {
            var policies = _policeApplication.GetAllPolicesWrapper();
            var clients = _clientApplication.GetAllClientsWrapper();

            var firstOrDefault = policies.Policies.FirstOrDefault(policieUser => policieUser.id.Equals(policeNumber));
            if (firstOrDefault != null)
            {
                var userPolice = firstOrDefault.clientId;

                var clientLinked = clients.Clients.FirstOrDefault(linkedClient => linkedClient.id.Equals(userPolice));

                if (clientLinked == null)
                {
                
                }
                return Request.CreateResponse(HttpStatusCode.Created, JsonConvert.SerializeObject(clientLinked));
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

    }
}
