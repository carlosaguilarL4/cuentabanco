using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.BL
{
    public class Movimiento
    {
        public int Id { get; set; }
        public string Detalle { get; set; }
        public double Deposito { get; set; }
        public double Retiro { get; set; }
    }
}
