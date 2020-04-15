using NomadWork.Domain.Interfaces.Characteristics;
using NomadWork.Infra.Models;

namespace NomadWork.Infra.Interfaces
{
    interface ICharacteristicInfra : ICharacteristicDomain<CharacteristicDb>
    {
    }
}
