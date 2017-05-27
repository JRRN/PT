using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.Services.Polices;
using Domain.Services.Polices;

namespace Application.Logic.Services.Polices
{
    public class PoliceApplication : IPoliceApplication
    {
        private readonly IPoliceLogic _policeLogic;

        public PoliceApplication(IPoliceLogic policeLogic)
        {
            _policeLogic = policeLogic;
        }

        public Domain.Model.Polices GetById(int entityId)
        {
            return _policeLogic.GetById(entityId);
        }

        public IEnumerable<Domain.Model.Polices> GetPoliceByName(string name)
        {
            return _policeLogic.FindByName(name);
        }

        public Domain.Model.Polices GetByName(string entityName)
        {
            return _policeLogic.FindByName(entityName).FirstOrDefault();
        }

        public IEnumerable<Domain.Model.Polices> GetAllPolices()
        {
            return _policeLogic.GetAll();
        }
    }
}