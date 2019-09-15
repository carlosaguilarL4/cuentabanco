using EstadodeCuenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstadodeCuenta.Web.Controllers
{
    public class ClientesController : Controller
    {
        ClientesBL _ClientesBL;

        public ClientesController()
        {
            _ClientesBL = new ClientesBL();
        }
        // GET: Clientes
        public ActionResult Index()
        {
            var listadeClientes = _ClientesBL.ObtenerClientes();

            return View(listadeClientes);
        }

        
    }
}
