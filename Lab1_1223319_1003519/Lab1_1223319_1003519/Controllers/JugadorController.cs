using System;
using Lab1_1223319_1003519.Helpers;
using Lab1_1223319_1003519.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomGenerics.Estructuras;
using System.IO;

namespace Lab1_1223319_1003519.Controllers
{
    public class JugadorController : Controller
    {
        public bool EnListaEnlazada = true;
        
        // GET: Jugador
        public ActionResult Index()
        {
            Storage.Instance.busquedajugador.Clear();
            // var jugadores = Storage.Instance.JugadorList; 
            //jugadores.Add(new Jugador { Nombre = "Thomas", Apellido = "Müller", Posición = "Delantero", Salario = 1000000, Club = "Bayern" });
            //jugadores.Add(new Jugador { Nombre = "ewe", Apellido = "Contreras", Posición = "Mediocampista", Salario = 2000000, Club = "Comunicaciones" });
            //jugadores.Add(new Jugador { Nombre = "ewe", Apellido = "Crackpollo", Posición = "Delantero", Salario = 999999999, Club = "Mixco" });
            if (EnListaEnlazada)
            {
                return View(Storage.Instance.JugadorListaEnlazada);
            }
            else
            {
                return View(Storage.Instance.JugadorList);
            }
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
                {
                    ID = Storage.Instance.JugadorList.Count() + 1,
                    Nombre = collection["Nombre"],
                    Apellido = collection["Apellido"],
                    Posición = collection["Posición"],
                    Salario = double.Parse(collection["Salario"]),                 
                    Club = collection["Club"],
                };
                if (EnListaEnlazada)
                {
                    jugador.ID = Storage.Instance.JugadorListaEnlazada.Count + 1;
                }
                if (jugador.Save(EnListaEnlazada))
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
            if (EnListaEnlazada)
            {
                try
                {
                    for (int i = 0; i < Storage.Instance.JugadorListaEnlazada.Count; i++)
                    {
                        if (Storage.Instance.JugadorListaEnlazada.Get(i).ID.Equals(id))
                        {
                            {
                                var jugador = new Jugador
                                {
                                    ID = id,
                                    Nombre = collection["Nombre"],
                                    Apellido = collection["Apellido"],
                                    Posición = collection["Posición"],
                                    Salario = double.Parse(collection["Salario"]),
                                    Club = collection["Club"],
                                };
                                Storage.Instance.JugadorListaEnlazada.Set(jugador, i);
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
            else
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

        public ActionResult AbrirArchivo()
        {
            StreamReader stream = new StreamReader(Jugador.FileUpload.InputStream);
            string text = stream.ReadToEnd();
            text += "\n";
            return RedirectToAction("Index"); ;
        }
    }
}
