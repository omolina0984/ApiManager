using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Dominio.ApiManager.Entidades.Entidades
{
    [Table("TipoMovimiento")]
    public partial class TipoMovimiento
    {
        public TipoMovimiento()
        {
            Movimientos = new HashSet<Movimiento>();
        }

        [Key]
        public int TipoMovimientoId { get; set; }
        [StringLength(50)]
        public string DescripcionMovimiento { get; set; }

        [InverseProperty(nameof(Movimiento.TipoMovimiento))]
        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}
