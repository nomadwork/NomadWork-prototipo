using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadWork.Api.Models
{
    [Table("Establishmment")]
    public class EstablishmmentModel 
    {
        public EstablishmmentModel()
        {
            Characteristics = new List<CharacteristicModel>();
        }

        [Required, Column(TypeName = "char(6)"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public UserModel Owner { get; set; }

        [Required]
        public AddressModel Address { get; set; }

        [Required]
        public List<CharacteristicModel> Characteristics { get; set; }
    }
}
