﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadodeCuenta.BL
{
    public class OrdenesBL
    {
        Contexto _contexto;
        public List<Orden> ListadeOrdenes { get; set; }

        public OrdenesBL()
        {
            _contexto = new Contexto();
            ListadeOrdenes = new List<Orden>();
        }

        public List<Orden> ObtenerOrdenes()
        {
            ListadeOrdenes = _contexto.Ordenes
                .Include("Cliente")
                .OrderBy(r => r.Cliente.Nombre)
                .ThenBy(r => r.Fecha)
                .ToList();

            return ListadeOrdenes;
        }

        public List<OrdenDetalle> ObtenerOrdenDetalle(int ordenId)
        {
            var listadeOrdenesDetalle = _contexto.OrdenDetalle
                .Include("Producto")
                .Where(o => o.OrdenId == ordenId)
                .OrderBy(r => r.Id)
                .ToList();

            return listadeOrdenesDetalle;
        }

        public OrdenDetalle ObtenerOrdenDetallePorId(int id)
        {
            var ordenDetalle = _contexto.OrdenDetalle
                .Include("Producto").FirstOrDefault(p => p.Id == id);

            return ordenDetalle;
        }

        public Orden ObtenerOrden(int id)
        {
            var orden = _contexto.Ordenes
                .Include("Cliente").FirstOrDefault(p => p.Id == id);

            return orden;
        }

        public void GuardarOrden(Orden orden)
        {
            if (orden.Id == 0)
            {
                _contexto.Ordenes.Add(orden);
            }
            else
            {
                var ordenExistente = _contexto.Ordenes.Find(orden.Id);
                ordenExistente.ClienteId = orden.ClienteId;
                ordenExistente.Activo = orden.Activo;
            }

            _contexto.SaveChanges();
        }

        public void GuardarOrdenDetalle(OrdenDetalle ordenDetalle)
        {
            var Tipo = _contexto.Tipos.Find(ordenDetalle.ProductoId);

            ordenDetalle.Precio = Tipo.Precio;
            ordenDetalle.Total = ordenDetalle.Cantidad * ordenDetalle.Precio;

            _contexto.OrdenDetalle.Add(ordenDetalle);

            var orden = _contexto.Ordenes.Find(ordenDetalle.OrdenId);
            orden.Total = orden.Total + ordenDetalle.Total;

            _contexto.SaveChanges();
        }

        public void EliminarOrdenDetalle(int id)
        {
            var ordenDetalle = _contexto.OrdenDetalle.Find(id);
            _contexto.OrdenDetalle.Remove(ordenDetalle);

            var orden = _contexto.Ordenes.Find(ordenDetalle.OrdenId);
            orden.Total = orden.Total - ordenDetalle.Total;

            _contexto.SaveChanges();
        }
    }
}
