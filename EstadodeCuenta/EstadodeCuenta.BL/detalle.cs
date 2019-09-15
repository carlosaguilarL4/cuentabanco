using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadodeCuenta.BL
{
    public class detalle
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese una descripción")]
        public string Descripcion { get; set; }
    }
}
