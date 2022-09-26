using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.ApiManager.Entidades.Entidades
{
    public class Persona
    {
        [Required]
        [StringLength(200)]
        public string Nombres { get; set; }
        [StringLength(350)]
        public string Direccion { get; set; }
        [StringLength(11)]
        public string Telefono { get; set; }


        [StringLength(15)]
        public string Genero { get; set; }
        public int? Edad { get; set; }
        [StringLength(13)]
        public string Identificacion { get; set; }




    }
}
