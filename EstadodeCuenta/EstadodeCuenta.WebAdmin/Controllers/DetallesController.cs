using EstadodeCuenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstadodeCuenta.WebAdmin.Controllers
{
    public class DetallesController : Controller
    {
        DetallesBL _DetallesBL;

        public DetallesController()
        {
            _DetallesBL = new DetallesBL();
        }

        // GET: Detalles
        public ActionResult Index()
        {
            var listadeDetalles = _DetallesBL.ObtenerDetalles();

            return View(listadeDetalles);
        }

        public ActionResult Crear()
        {
            var nuevadetalle = new detalle();

            return View(nuevadetalle);
        }

        [HttpPost]
        public ActionResult Crear(detalle detalle)
        {
            if (ModelState.IsValid)
            {
                if (detalle.Descripcion != detalle.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripción no debe contener espacios al inicio o al final");
                    return View(detalle);
                }

                _DetallesBL.Guardardetalle(detalle);

                return RedirectToAction("Index");
            }

            return View(detalle);
        }

        public ActionResult Editar(int id)
        {
            var producto = _DetallesBL.Obtenerdetalle(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(detalle producto)
        {
            _DetallesBL.Guardardetalle(producto);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var producto = _DetallesBL.Obtenerdetalle(id);

            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _DetallesBL.Obtenerdetalle(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(detalle producto)
        {
            _DetallesBL.Eliminardetalle(producto.Id);

            return RedirectToAction("Index");
        }
    }
}