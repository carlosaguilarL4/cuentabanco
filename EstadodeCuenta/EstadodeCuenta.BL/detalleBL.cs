using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadodeCuenta.BL
{
    public class DetallesBL
    {
        Contexto _contexto;
        public List<detalle> ListadeDetalles { get; set; }

        public DetallesBL()
        {
            _contexto = new Contexto();
            ListadeDetalles = new List<detalle>();
        }

        public List<detalle> ObtenerDetalles()
        {
            ListadeDetalles = _contexto.Detalles.ToList();
            return ListadeDetalles;
        }

        public void Guardardetalle(detalle detalle)
        {
            if (detalle.Id == 0)
            {
                _contexto.Detalles.Add(detalle);
            }
            else
            {
                var detalleExistente = _contexto.Detalles.Find(detalle.Id);
                detalleExistente.Descripcion = detalle.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public detalle Obtenerdetalle(int id)
        {
            var detalle = _contexto.Detalles.Find(id);

            return detalle;
        }

        public void Eliminardetalle(int id)
        {
            var detalle = _contexto.Detalles.Find(id);

            _contexto.Detalles.Remove(detalle);
            _contexto.SaveChanges();
        }
    }
}
