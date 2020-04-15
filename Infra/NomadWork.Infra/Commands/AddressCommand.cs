using Microsoft.EntityFrameworkCore;
using NomadWork.Domain.Account.Location;
using NomadWork.Infra.Context;
using NomadWork.Infra.Interfaces;
using NomadWork.Infra.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NomadWork.Infra.Commands
{
    public class AddressCommand : IAddressInfra
    {
        private readonly NomadWorkDbContext _db;

        public AddressCommand(NomadWorkDbContext db)
        {
            _db = db;
        }

        public Address Create(Address address)
        {
            var a = ToConvert(address);

            if (!address.Erro)
            {
                _db.Addresses.Add(a);
                _db.SaveChanges();
            }

            return address;
        }

        public Address Update(Address address)
        {
            throw new NotImplementedException();
        }

        public Address Delete(Address address)
        {
            throw new NotImplementedException();
        }

        public List<Address> Find(Address address)
        {
            var adrressDb = _db.Addresses.Find().Where(x => x.);
            throw new NotImplementedException();
        }

        public Address FindById(string id)
        {
            var adrressDb = _db.Addresses.Find(id);
            return ToConvert(adrressDb);
        }

        public List<Address> FindNearby(Address address)
        {
            throw new NotImplementedException();
        }

        public Address ToConvert(AddressDb address)
        {
            return Address.Create(address.Street,address.Number,address.Zipcode,address.Coutry,address.Street,address.Latitude,address.Longitude);
        }

        public AddressDb ToConvert(Address address)
        {
            return new AddressDb
            {
                Id = address.Id,
                Coutry = address.Coutry,
                Number = address.Number,
                State = address.State,
                Street = address.Street,
                Zipcode = address.ZipCode,
                Latitude = address.Latitude,
                Longitude = address.Longitude
            };
        }

    }
}
