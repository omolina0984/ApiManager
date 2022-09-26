using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ApiManager.Entidades.Entidades
{
    public class Deposito
    {
        public long Cuenta { get; set; }

        public string Identificacion { get; set; }
        public decimal valor { get; set; }
        public int tipo { get; set; }


    }
}
