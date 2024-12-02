using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiramideRectangularFinalProg.Entidades
{
    public class PiramideRectangular
    {

        public int LadoBase { get; set; }
        public int Altura { get; set; }
        public int CantidadLados { get; set; }
        public PiramideColor Color { get; set; }
        public PiramideMaterial Material { get; set; }

        public PiramideRectangular() { }

        public PiramideRectangular(int ladoBase, int altura, int cantidadLados, PiramideColor color, PiramideMaterial material)
        {
            LadoBase = ladoBase;
            Altura = altura;
            CantidadLados = cantidadLados;
            Color = color;
            Material = material;
        }

        public double CalcularAreaBase()
        {

            if(CantidadLados >= 3)
            {
                return (Math.Pow(Math.Sqrt(3), 2) / 4 * Math.Pow(LadoBase, 2));
            } else if(CantidadLados >= 4)
            {
                return Math.Pow(LadoBase, 2);
            } else
            {
                return 0;
            }

        }

        public double CalcularVolumen()
        {
            return (CalcularAreaBase() * Altura) / 2;
        }

        private double CalcularPerimetroBase()
        {
            return LadoBase * CantidadLados;
        }

        private double CalcularAlturaLateral()
        {
            return Math.Pow(Math.Sqrt(Math.Pow(Altura, 2) + Math.Pow(LadoBase / 2, 2)), 2);
        }

        public double CalcularAreaLateral()
        {
            return (CalcularPerimetroBase() * CalcularAlturaLateral()) / 2;
        }

        public double CalcularAreaTotal()
        {
            return CalcularAreaBase() + CalcularAreaLateral();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Volumen: {CalcularVolumen().ToString("N2")}");
            sb.AppendLine($"Perimetro Base: {CalcularPerimetroBase().ToString("N2")}");
            sb.AppendLine($"Altura Lateral: {CalcularAlturaLateral().ToString("N2")}");
            sb.AppendLine($"Area Lateral: {CalcularAreaLateral().ToString("N2")}");
            sb.AppendLine($"Area Total: {CalcularAreaTotal().ToString("N2")}");

            return sb.ToString();

        }

    }
}
