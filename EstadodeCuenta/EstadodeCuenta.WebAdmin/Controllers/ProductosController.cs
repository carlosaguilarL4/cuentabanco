using EstadodeCuenta.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstadodeCuenta.WebAdmin.Controllers
{
    public class ProductosController : Controller
    {
        ProductosBL _productosBL;
        TiposBL _TiposBL;

        public ProductosController()
        {
            _productosBL = new ProductosBL();
            _TiposBL = new TiposBL();
        }

        // GET: Productos
        public ActionResult Index()
        {
            var listadeProductos = _productosBL.ObtenerProductos();

            return View(listadeProductos);
        }

        public ActionResult Crear()
        {
            var nuevoProducto = new Producto();
            var Tipos = _TiposBL.ObtenerTipos();


            ViewBag.TipoId =
                new SelectList(Tipos, "Id", "Descripcion");

            return View(nuevoProducto);
        }

        [HttpPost]
        public ActionResult Crear(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (producto.TipoId == 0)
                {
                    ModelState.AddModelError("TipoId", "Seleccione una Tipo");
                    return View(producto);
                }

                if (imagen != null)
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }

                _productosBL.GuardarProducto(producto);

                return RedirectToAction("Index");
            }

            var Tipos = _TiposBL.ObtenerTipos();

            ViewBag.TipoId =
                new SelectList(Tipos, "Id", "Descripcion");

            return View(producto);
        }

        public ActionResult Editar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);
            var Tipos = _TiposBL.ObtenerTipos();

            ViewBag.TipoId =
                new SelectList(Tipos, "Id", "Descripcion", producto.TipoId);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Editar(Producto producto, HttpPostedFileBase imagen)
        {
            if (ModelState.IsValid)
            {
                if (producto.TipoId == 0)
                {
                    ModelState.AddModelError("TipoId", "Seleccione una Tipo");
                    return View(producto);
                }

                if (imagen != null)
                {
                    producto.UrlImagen = GuardarImagen(imagen);
                }

                _productosBL.GuardarProducto(producto);

                return RedirectToAction("Index");
            }

            var Tipos = _TiposBL.ObtenerTipos();

            ViewBag.TipoId =
                new SelectList(Tipos, "Id", "Descripcion");

            return View(producto);
        }

        public ActionResult Detalle(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);

            return View(producto);
        }

        public ActionResult Eliminar(int id)
        {
            var producto = _productosBL.ObtenerProducto(id);

            return View(producto);
        }

        [HttpPost]
        public ActionResult Eliminar(Producto producto)
        {
            _productosBL.EliminarProducto(producto.Id);

            return RedirectToAction("Index");
        }

        private string GuardarImagen(HttpPostedFileBase imagen)
        {
            string path = Server.MapPath("~/Imagenes/" + imagen.FileName);
            imagen.SaveAs(path);

            return "/Imagenes/" + imagen.FileName;
        }
    }
}