using System;
using Lab1_1223319_1003519.Helpers;
using Lab1_1223319_1003519.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomGenerics.Estructuras;

namespace Lab1_1223319_1003519.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index()
        {
            Storage.Instance.busquedajugador.Clear();
            // var jugadores = Storage.Instance.JugadorList; 
            //jugadores.Add(new Jugador { Nombre = "Thomas", Apellido = "Müller", Posición = "Delantero", Salario = 1000000, Club = "Bayern" });
            //jugadores.Add(new Jugador { Nombre = "ewe", Apellido = "Contreras", Posición = "Mediocampista", Salario = 2000000, Club = "Comunicaciones" });
            //jugadores.Add(new Jugador { Nombre = "ewe", Apellido = "Crackpollo", Posición = "Delantero", Salario = 999999999, Club = "Mixco" });
            return View(Storage.Instance.JugadorList);
        }
        ListaEnlazada<Jugador> jugadorListN = new ListaEnlazada<Jugador>();
        public ActionResult Listas()
        {
            
            return View(Storage.Instance.busquedajugador);
        }

        // GET: Jugador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var jugador = new Jugador
                {   ID = Storage.Instance.JugadorList.Count() + 1,
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Posición = collection["Posición"],
                    Salario = double.Parse(collection["Salario"]),                 
                    Club = collection["Club"],
                };
                if (jugador.Save())
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(jugador);
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int id)
        {
            return View("");
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                
                for (int i = 0; i < Storage.Instance.JugadorList.Count; i++)
                {
                    if (Storage.Instance.JugadorList[i].ID.Equals(id))
                    {
                        
                        {
                            Storage.Instance.JugadorList[i].Nombre = collection["Nombre"];
                            Storage.Instance.JugadorList[i].Apellido = collection["Apellido"];
                            Storage.Instance.JugadorList[i].Posición = collection["Posición"];
                            Storage.Instance.JugadorList[i].Salario = double.Parse(collection["Salario"]);
                            Storage.Instance.JugadorList[i].Club = collection["Club"];
                        };
                       
                    }

                       
                    }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Jugador/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //public ActionResult BuscarNombre(string parametro)
        //{
        //    parametro = "ewe";
        //    int i = 0;
        //    while ( i>2)
        //    {
        //        if(Storage.Instance.jugadorList.First.Valor.Nombre == parametro)
        //        {
        //            jugadorListN.Add(Storage.Instance.jugadorList.First.Valor);
        //        }
        //        Storage.Instance.jugadorList.First = Storage.Instance.jugadorList.First.Siguiente;
        //        i++;
        //    }
        //    return RedirectToAction("Listas");
        //}
       
        public ActionResult BuscarNombre (string parametro)
        {
            parametro = "ewe";
            for(int i= 0; i< Storage.Instance.JugadorList.Count; i++)
            {
                if (Storage.Instance.JugadorList[i].Nombre.Equals(parametro))
                {
                    Storage.Instance.busquedajugador.Add(Storage.Instance.JugadorList[i]);
                }
            }
         return RedirectToAction("Listas");
        }
      
    }
}
