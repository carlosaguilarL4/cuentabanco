using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadodeCuenta.BL
{
    public class TiposBL
    {
        Contexto _contexto;
        public List<Tipo> ListadeTipos { get; set; }

        public TiposBL()
        {
            _contexto = new Contexto();
            ListadeTipos = new List<Tipo>();
        }

        public List<Tipo> ObtenerTipos()
        {
            ListadeTipos = _contexto.Tipos.ToList();
            return ListadeTipos;
        }

        public void GuardarTipo(Tipo Tipo)
        {
            if (Tipo.Id == 0)
            {
                _contexto.Tipos.Add(Tipo);
            }
            else
            {
                var TipoExistente = _contexto.Tipos.Find(Tipo.Id);
                TipoExistente.Descripcion = Tipo.Descripcion;
            }

            _contexto.SaveChanges();
        }

        public Tipo ObtenerTipo(int id)
        {
            var Tipo = _contexto.Tipos.Find(id);

            return Tipo;
        }

        public void EliminarTipo(int id)
        {
            var Tipo = _contexto.Tipos.Find(id);

            _contexto.Tipos.Remove(Tipo);
            _contexto.SaveChanges();
        }
    }
}
