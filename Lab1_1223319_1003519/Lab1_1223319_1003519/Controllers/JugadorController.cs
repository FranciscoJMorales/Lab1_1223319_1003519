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
    public delegate bool Condition(int x, int y);

    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index()
        {
            Storage.Instance.busquedajugador.Clear();
            // var jugadores = Storage.Instance.JugadorList; 
            if (Storage.Instance.EnListaEnlazada)
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
                if (Storage.Instance.EnListaEnlazada)
                {
                    jugador.ID = Storage.Instance.JugadorListaEnlazada.Count + 1;
                }
                if (jugador.Save(Storage.Instance.EnListaEnlazada))
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
            if (Storage.Instance.EnListaEnlazada)
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
            if (Storage.Instance.EnListaEnlazada)
            {
                try
                {
                    for (int i = 0; i < Storage.Instance.JugadorListaEnlazada.Count; i++)
                    {
                        if (Storage.Instance.JugadorListaEnlazada.Get(i).ID.Equals(id))
                        {
                            Storage.Instance.JugadorListaEnlazada.Delete(i);
                        }
                    }
                    for (int i = 0; i < Storage.Instance.JugadorListaEnlazada.Count; i++)
                    {
                        if (Storage.Instance.JugadorListaEnlazada.Get(i).ID > id)
                        {
                            Jugador aux = Storage.Instance.JugadorListaEnlazada.Get(i);
                            aux.ID--;
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

                            Storage.Instance.JugadorList.Remove(Storage.Instance.JugadorList[i]);
                        }
                    }
                    for (int i = 0; i < Storage.Instance.JugadorList.Count; i++)
                    {
                        if (Storage.Instance.JugadorList[i].ID > id)
                        {

                            Storage.Instance.JugadorList[i].ID--;
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

        public ActionResult BuscarNombre(string parametro)
        {
            parametro = "ewe";
            for (int i = 0; i < Storage.Instance.JugadorList.Count; i++)
            {
                if (Storage.Instance.JugadorList[i].Nombre.Equals(parametro))
                {
                    Storage.Instance.busquedajugador.Add(Storage.Instance.JugadorList[i]);
                }
            }
            return RedirectToAction("Listas");
        }

        [HttpPost]
        public ActionResult AbrirArchivo(HttpPostedFileBase file)
        {
            StreamReader stream = new StreamReader(file.InputStream);
            string text = stream.ReadToEnd();
            if (Storage.Instance.EnListaEnlazada)
                Storage.Instance.JugadorListaEnlazada.Clear();
            else
                Storage.Instance.JugadorList.Clear();
            while (text.IndexOf("\r\n") >= 0)
            {
                Jugador nuevo = new Jugador();
                nuevo.ID = Storage.Instance.JugadorList.Count() + 1;
                if (Storage.Instance.EnListaEnlazada)
                {
                    nuevo.ID = Storage.Instance.JugadorListaEnlazada.Count + 1;
                }
                nuevo.Nombre = text.Substring(0, text.IndexOf(";"));
                text = text.Remove(0, text.IndexOf(";") + 1);
                nuevo.Apellido = text.Substring(0, text.IndexOf(";"));
                text = text.Remove(0, text.IndexOf(";") + 1);
                nuevo.Posición = text.Substring(0, text.IndexOf(";"));
                text = text.Remove(0, text.IndexOf(";") + 1);
                nuevo.Salario = Double.Parse(text.Substring(0, text.IndexOf(";")));
                text = text.Remove(0, text.IndexOf(";") + 1);
                nuevo.Club = text.Substring(0, text.IndexOf("\r\n"));
                text = text.Remove(0, text.IndexOf("\r\n") + 2);
                nuevo.Save(Storage.Instance.EnListaEnlazada);
            }
            return RedirectToAction("Index"); ;
        }

        public ActionResult ListaArtesanal()
        {
            Storage.Instance.EnListaEnlazada = true;
            return RedirectToAction("Index");
        }

        public ActionResult ListaCS()
        {
            Storage.Instance.EnListaEnlazada = false;
            return RedirectToAction("Index");
        }

        public static Condition Igual = delegate (int x, int y)
        {
            return x == y;
        };

        public static Condition Menor = delegate (int x, int y)
        {
            return x < y;
        };

        public static Condition Mayor = delegate (int x, int y)
        {
            return x > y;
        };
    }
}
