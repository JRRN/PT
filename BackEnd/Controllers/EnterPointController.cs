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

        public EnterPointController(IMapper mapper, IAuthorization authorization, IClientApplication clientApplication) 
            : base(mapper, authorization)
        {
            _clientApplication = clientApplication;
        }


        // GET: api/Clients/5
        [Authorize(Roles = "users, admin")]
        public string GetClientById(int id)
        {
            return JsonConvert.SerializeObject(_clientApplication.GetById(id));
        }

        [Authorize(Roles = "users, admin")]
        public string GetClientByUserName(string clientName)
        {
            var policeEntity = _clientApplication.GetByName(clientName);
            return JsonConvert.SerializeObject(policeEntity);
        }

        [Authorize(Roles = "admin")]
        public string GetPolicesByClient(string UserName)
        {
            var idClient = _clientApplication.GetAll().FirstOrDefault(client => client.Name.Equals(UserName)).ObjectId;
            var policeEntity = _policeApplication.GetAllPolices().Where(police => police.clientId.Equals(idClient));
            return JsonConvert.SerializeObject(policeEntity);
        }

        [Authorize(Roles = "admin")]
        public string GetLinked(string policeNumber)
        {
            var policeClient = _policeApplication.GetAllPolices().FirstOrDefault(police => police.Id.Equals(policeNumber));
            var clientPoliceAssociated = _clientApplication.GetById(policeClient.Id);
            return JsonConvert.SerializeObject(clientPoliceAssociated);
        }
    }
}
