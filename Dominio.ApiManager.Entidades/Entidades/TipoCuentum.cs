using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.ApiManager.Entidades.Entidades
{
    public partial class TipoCuentum
    {
        public TipoCuentum()
        {
            CuentaNavigation = new HashSet<Cuentum>();
        }

        [Key]
        public int TipoCuentaId { get; set; }
        [StringLength(50)]
        public string Cuenta { get; set; }

        [InverseProperty(nameof(Cuentum.TipoCuenta))]
        public virtual ICollection<Cuentum> CuentaNavigation { get; set; }
    }
}
