using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadodeCuenta.BL
{
    public class OrdenBL
    {
        Contexto _contexto;
        public List<Orden> ListadeOrden { get; set; }

        public OrdenBL()
        {
            _contexto = new Contexto();
            ListadeOrden = new List<Orden>();
        }

        public List<Orden> ObtenerOrden()
        {
            ListadeOrden = _contexto.Orden
                .Include("Cliente")
                .OrderBy(r => r.Cliente.Nombre)
                .ThenBy(r => r.Fecha)
                .ToList();

            return ListadeOrden;
        }

        public List<OrdenDetalle> ObtenerOrdenDetalle(int ordenId)
        {
            var listadeOrdenDetalle = _contexto.OrdenDetalle
                .Include("Producto")
                .Where(o => o.OrdenId == ordenId)
                .OrderBy(r => r.Id)
                .ToList();

            return listadeOrdenDetalle;
        }

        public OrdenDetalle ObtenerOrdenDetallePorId(int id)
        {
            var ordenDetalle = _contexto.OrdenDetalle
                .Include("Producto").FirstOrDefault(p => p.Id == id);

            return ordenDetalle;
        }

        public Orden ObtenerOrden(int id)
        {
            var orden = _contexto.Orden
                .Include("Cliente").FirstOrDefault(p => p.Id == id);

            return orden;
        }

        public void GuardarOrden(Orden orden)
        {
            if (orden.Id == 0)
            {
                _contexto.Orden.Add(orden);
            }
            else
            {
                var ordenExistente = _contexto.Orden.Find(orden.Id);
                ordenExistente.ClienteId = orden.ClienteId;
                ordenExistente.Activo = orden.Activo;
            }

            _contexto.SaveChanges();
        }

        public void GuardarOrdenDetalle(OrdenDetalle ordenDetalle)
        {
            var producto = _contexto.Productos.Find(ordenDetalle.ProductoId);

            ordenDetalle.Precio = producto.Precio;
            ordenDetalle.Total = ordenDetalle.Cantidad * ordenDetalle.Precio;

            _contexto.OrdenDetalle.Add(ordenDetalle);

            var orden = _contexto.Orden.Find(ordenDetalle.OrdenId);
            orden.Total = orden.Total + ordenDetalle.Total;

            _contexto.SaveChanges();
        }

        public void EliminarOrdenDetalle(int id)
        {
            var ordenDetalle = _contexto.OrdenDetalle.Find(id);
            _contexto.OrdenDetalle.Remove(ordenDetalle);

            var orden = _contexto.Orden.Find(ordenDetalle.OrdenId);
            orden.Total = orden.Total - ordenDetalle.Total;

            _contexto.SaveChanges();
        }
    }
}
