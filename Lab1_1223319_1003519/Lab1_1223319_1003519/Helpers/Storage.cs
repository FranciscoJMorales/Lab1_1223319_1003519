using System;
using Lab1_1223319_1003519.Models;
using CustomGenerics.Estructuras;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab1_1223319_1003519.Helpers
{
    public class Storage
    {

        private static Storage _instance;
     
        public static Storage Instance
        {
            get
            {
                if (_instance == null) _instance = new Storage() ;
                return _instance;
            }
        }

       public ListaEnlazada<Jugador> JugadorListaEnlazada = new ListaEnlazada<Jugador>();
       public List<Jugador> JugadorList = new List<Jugador>();
       public List<Jugador> resultadosBusqueda = new List<Jugador>();
       public ListaEnlazada<Jugador> resultadosListaEnlazada = new ListaEnlazada<Jugador>();
       public bool EnListaEnlazada = true;
       public List<Tiempo> Log = new List<Tiempo>();
    }
}