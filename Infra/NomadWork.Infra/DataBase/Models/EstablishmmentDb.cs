﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadWork.Infra.Models
{
    [Table("Establishmment")]
    public class EstablishmmentDb 
    {
        public EstablishmmentDb()
        {
            Characteristics = new List<CharacteristicDb>();
        }

        [Required, Column(TypeName = "char(6)"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public UserDb Owner { get; set; }

        [Required]
        public AddressDb Address { get; set; }

        [Required]
        public List<CharacteristicDb> Characteristics { get; set; }
    }
}
