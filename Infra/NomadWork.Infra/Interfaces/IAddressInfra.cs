using NomadWork.Domain.Interfaces.Addresses;
using NomadWork.Infra.Models;

namespace NomadWork.Infra.Interfaces
{
    interface IAddressInfra : IAddressDomain<AddressDb>
    {
    }
}
