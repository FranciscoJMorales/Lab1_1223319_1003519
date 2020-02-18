using System;
using CustomGenerics.Estructuras;
using Lab1_1223319_1003519.Controllers;
using Lab1_1223319_1003519.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab1_1223319_1003519.Models
{
    public class Jugador
    {
        [Required]

        public int ID { get; set; }
        [Required]
        [Display(Name="Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Required]
        public string Posición { get; set; }
        [Required]
        public double Salario { get; set; }
        [Required]
        public string Club { get; set; }

        public static HttpPostedFileBase FileUpload { get; set; }

        public static Comparison<Jugador> CompararNombre = delegate (Jugador j1, Jugador j2)
        {
            return j1.Nombre.ToLower().CompareTo(j2.Nombre.ToLower());
        };

        public static Comparison<Jugador> CompararApellido = delegate (Jugador j1, Jugador j2)
        {
            return j1.Apellido.ToLower().CompareTo(j2.Apellido.ToLower());
        };

        public static Comparison<Jugador> CompararPosicion = delegate (Jugador j1, Jugador j2)
        {
            return j1.Posición.ToLower().CompareTo(j2.Posición.ToLower());
        };

        public static Comparison<Jugador> CompararClub = delegate (Jugador j1, Jugador j2)
        {
            return j1.Club.ToLower().CompareTo(j2.Club.ToLower());
        };
       
        internal bool Save(bool EnListaEnlazada)
        {
            try
            {
                if (EnListaEnlazada)
                {
                    Storage.Instance.JugadorListaEnlazada.Add(this);
                }
                else
                {
                    Storage.Instance.JugadorList.Add(this);
                }
                
                //Storage.Instance.jugadorlist.Add(this);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}