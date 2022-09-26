using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.ApiManager.Entidades.Entidades
{
    public partial class Cuentum
    {
        public Cuentum()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        [Key]
        public int CuentaId { get; set; }
        public long? NumeroCuenta { get; set; }
        public int? TipoCuentaId { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public int? ClienteId { get; set; }

        [ForeignKey(nameof(ClienteId))]
        [InverseProperty("Cuenta")]
        public virtual Cliente Cliente { get; set; }
        [ForeignKey(nameof(TipoCuentaId))]
        [InverseProperty(nameof(TipoCuentum.CuentaNavigation))]
        public virtual TipoCuentum TipoCuenta { get; set; }
        [InverseProperty(nameof(Movimiento.Cuenta))]
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
