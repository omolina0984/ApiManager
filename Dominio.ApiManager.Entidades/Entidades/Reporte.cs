using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ApiManager.Entidades.Entidades
{
    public class Reporte
    {


        public DateTime? Fecha { get; set; }
        public string Cliente { get; set; }
        public long? NumeroCuenta { get; set; }
        public string Tipo { get; set; }
        public decimal? SaldoInicial { get; set; }
        public bool? Estado { get; set; }
        public decimal? Movimiento { get; set; }
        public decimal? Saldo { get; set; }
        public string DetalleTransaccion { get; set; }
        public string TipoTransaccion { get; set; }

        



    }
}
