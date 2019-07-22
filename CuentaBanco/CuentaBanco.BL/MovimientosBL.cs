using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuentaBanco.BL
{
    public class MovimientosBL
    {
       public List<Movimiento> ObtenerMovimiento()
        {
            var movimiento1 = new Movimiento();
            movimiento1.Id = 1;
            movimiento1.Detalle = "Deposito";
            movimiento1.Deposito = 200;


            var movimiento2 = new Movimiento();
            movimiento2.Id = 2;
            movimiento2.Detalle = "Retiro";
            movimiento1.Retiro = 100;


            var movimiento3 = new Movimiento();
            movimiento3.Id = 3;
            movimiento3.Detalle = "Saldo";

            var listadeMovimientos = new List<Movimiento>();
            listadeMovimientos.Add(movimiento1);
            listadeMovimientos.Add(movimiento2);
            listadeMovimientos.Add(movimiento3);

            return listadeMovimientos;
        }
    }
}
