using EstadodeCuenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstadodeCuenta.WebAdmin.Controllers
{
    public class TiposController : Controller
    {
        TiposBL _TiposBL;

        public TiposController()
        {
            _TiposBL = new TiposBL();
        }

        // GET: Tipos
        public ActionResult Index()
        {
            var listadeTipos = _TiposBL.ObtenerTipos();

            return View(listadeTipos);
        }

        public ActionResult Crear()
        {
            var nuevaTipo = new Tipo();

            return View(nuevaTipo);
        }

        [HttpPost]
        public ActionResult Crear(Tipo Tipo)
        {
            if (ModelState.IsValid)
            {
                if (Tipo.Descripcion != Tipo.Descripcion.Trim())
                {
                    ModelState.AddModelError("Descripcion", "La descripción no debe contener espacios al inicio o al final");
                    return View(Tipo);
                }

                _TiposBL.GuardarTipo(Tipo);

                return RedirectToAction("Index");
            }

            return View(Tipo);
        }

        public ActionResult Editar(int id)
        {
            var producto = _TiposBL.ObtenerTipo(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Tipo producto)
        {
            _TiposBL.GuardarTipo(producto);

            return RedirectToAction("Index");
        }

        public ActionResult Detalle(int id)
        {
            var producto = _TiposBL.ObtenerTipo(id);

            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _TiposBL.ObtenerTipo(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Tipo producto)
        {
            _TiposBL.EliminarTipo(producto.Id);

            return RedirectToAction("Index");
        }
    }
}