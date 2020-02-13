using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1_1223319_1003519.Models
{
    public class Jugador
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Posición { get; set; }
        public double Salario { get; set; }
        public string Club { get; set; }

        public static Comparison<Jugador> CompararNombre = delegate (Jugador j1, Jugador j2)
        {
            return j1.Nombre.ToLower().CompareTo(j2.Nombre.ToLower());
        };
    }
}