using CuentaBanco.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuentaBanco.Web.Controllers
{
    public class MovimientosController : Controller
    {
        // GET: Movimientos
        public ActionResult Index()
        {
            var movimiento1 = new MovimientoModel();
            movimiento1.Id = 1;
            movimiento1.Detalle = "Deposito";

            var movimiento2 = new MovimientoModel();
            movimiento2.Id = 2;
            movimiento2.Detalle = "Retiro";

            var movimiento3 = new MovimientoModel();
            movimiento3.Id = 3;
            movimiento3.Detalle = "Saldo";

            var listadeMovimientos = new List<MovimientoModel>();
            listadeMovimientos.Add(movimiento1);
            listadeMovimientos.Add(movimiento2);
            listadeMovimientos.Add(movimiento3);

            return View(listadeMovimientos);
        }
    }
}