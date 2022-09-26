using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.ApiManager.Entidades.Entidades
{
    public partial class Movimiento
    {
        [Key]
        public int MovimientoId { get; set; }
        public int? TipoMovimientoId { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? Valor { get; set; }
        public int CuentaId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? Saldo { get; set; }   
        [Column(TypeName = "numeric(15, 2)")]
        public decimal? SaldoAnterior { get; set; }
        [StringLength(50)]
        public string Detalle { get; set; }

        [ForeignKey(nameof(CuentaId))]
        [InverseProperty(nameof(Cuentum.Movimientos))]
        public virtual Cuentum Cuenta { get; set; }
        [ForeignKey(nameof(TipoMovimientoId))]
        [InverseProperty("Movimientos")]
        public virtual TipoMovimiento TipoMovimiento { get; set; }
    }
}
