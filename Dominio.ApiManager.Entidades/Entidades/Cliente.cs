using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.ApiManager.Entidades.Entidades
{
    [Table("Cliente")]
    public partial class Cliente : Persona
    {
        public Cliente()
        {
            Cuenta = new HashSet<Cuentum>();
        }

        [Key]
        public int ClienteId { get; set; }
        public string Contraseña { get; set; }
        public bool? Estado { get; set; }


        [InverseProperty(nameof(Cuentum.Cliente))]
        public virtual ICollection<Cuentum> Cuenta { get; set; }
    }
}
