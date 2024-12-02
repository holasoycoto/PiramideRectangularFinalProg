using PiramideRectangularFinalProg.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiramideRectangularFinalProg.Datos
{
    public class RepositorioPiramidesRectangulares
    {

        private List<PiramideRectangular> lista;

        public RepositorioPiramidesRectangulares()
        {

            lista = new List<PiramideRectangular>();

        }

        public void Agregar(PiramideRectangular piramide)
        {

            lista.Add(piramide);

        }

        public void Eliminar(PiramideRectangular piramide)
        {
            lista.Remove(piramide);
        }

        public bool Existe(PiramideRectangular piramide)
        {
            return lista.Any(p => p.LadoBase == piramide.LadoBase && p.Altura == piramide.Altura && p.CantidadLados == piramide.CantidadLados);
        }

        public int ObtenerCantidad()
        {
            return lista.Count;
        }

        public List<PiramideRectangular> ObtenerLista()
        {

            return lista;

        }

    }
}
