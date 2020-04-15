using NomadWork.Domain.Account.Enum;
using NomadWork.Domain.Account.Location;

namespace NomadWork.Domain.Account
{
    //TODO 
    public class Nomad : User
    {
        public Nomad(string userName, string numberPhone, string password, string email)
            : base(userName, numberPhone, password, email)
        {
            this.Type = UserType.Nomad;
        }

        public string Name { get; private set; }
        public Address GeoLocation { get; private set; }
    }

}
