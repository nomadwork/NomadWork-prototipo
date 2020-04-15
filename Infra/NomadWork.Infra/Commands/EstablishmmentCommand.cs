using NomadWork.Domain.Business;
using NomadWork.Infra.Context;
using NomadWork.Infra.Interfaces;
using NomadWork.Infra.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NomadWork.Infra.Commands
{
   public class EstablishmmentCommand : IEstablishmmentInfra
    {
        private readonly NomadWorkDbContext _db;

        public EstablishmmentCommand(NomadWorkDbContext db)
        {
            _db = db;
        }

        public Establishmment Create(EstablishmmentDb establishmment)
        {

             _db.Add(establishmment);
            _db.SaveChanges();
        }

        public Establishmment Delete(EstablishmmentDb establishmment)
        {
            throw new NotImplementedException();
        }

        public List<Establishmment> Find(EstablishmmentDb establishmment)
        {
            throw new NotImplementedException();
        }

        public Establishmment FindById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Establishmment> FindNearby(EstablishmmentDb establishmment)
        {
            throw new NotImplementedException();
        }

        public Establishmment Update(EstablishmmentDb establishmment)
        {
            throw new NotImplementedException();
        }
    }
}
