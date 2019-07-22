using CuentaBanco.BL;
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
            var movimientosBL = new MovimientosBL();
            var listadeMovimientos = movimientosBL.ObtenerMovimiento();


            return View(listadeMovimientos);
        }
    }
}