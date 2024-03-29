﻿
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NomadWork.Api.Models
{
    public class CharacteristicModel
    {
        [Required, Column(TypeName = "char(6)"), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; }

        [Required]
        public short HasNotHas { get;  set; }

        [Required]
        public short ServiceOffered { get;  set; }

        [Required]
        public short ServiceOfferedQuality { get;  set; }
    }
}
