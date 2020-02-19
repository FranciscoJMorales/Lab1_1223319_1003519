using System;
using Lab1_1223319_1003519.Helpers;
using Lab1_1223319_1003519.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CustomGenerics.Estructuras;
using System.IO;
using System.Diagnostics;

namespace Lab1_1223319_1003519.Controllers
{
    public delegate bool Condition(int x);

    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index()
        {
           
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

        public ActionResult Listas()
        {

            if (Storage.Instance.EnListaEnlazada)
                return View(Storage.Instance.resultadosListaEnlazada);
            else
                return View(Storage.Instance.resultadosBusqueda);
        }

        // GET: Jugador/Details/5
        public ActionResult Details()
        {
            return View("Log", Storage.Instance.Log);
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
            Stopwatch temporizador = new Stopwatch();
            try
            {
                temporizador.Start();
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
                    temporizador.Stop();
                    Storage.Instance.Log.Add(new Tiempo { Log = "Tiempo de creación: " + temporizador.Elapsed });
                    return RedirectToAction("Index");
                }
                else
                {
                    temporizador.Stop();
                    return View(jugador);
                }
            }
            catch
            {
                temporizador.Stop();
                return View();
            }
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int id)
        {
            if (Storage.Instance.EnListaEnlazada)
                return View("Edit", Storage.Instance.JugadorListaEnlazada.Get(id - 1));
            else
                return View("Edit", Storage.Instance.JugadorList[id - 1]);
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            Stopwatch temporizador = new Stopwatch();
            temporizador.Start();
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
                    temporizador.Stop();
                    Storage.Instance.Log.Add(new Tiempo { Log = "Tiempo de edición: " + temporizador.Elapsed });
                    return RedirectToAction("Index");
                }
                catch
                {
                    temporizador.Stop();
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
                    temporizador.Stop();
                    Storage.Instance.Log.Add(new Tiempo { Log = "Tiempo de edición: " + temporizador.Elapsed });
                    return RedirectToAction("Index");
                }
                catch
                {
                    temporizador.Stop();
                    return View();
                }
            }
        }

        // GET: Jugador/Delete/5
        public ActionResult Delete(int id)
        {
            Stopwatch temporizador = new Stopwatch();
            temporizador.Start();
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
                    temporizador.Stop();
                    Storage.Instance.Log.Add(new Tiempo { Log = "Tiempo de eliminación: " + temporizador.Elapsed });
                    return RedirectToAction("Index");
                }
                catch
                {
                    temporizador.Stop();
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
                    temporizador.Stop();
                    Storage.Instance.Log.Add(new Tiempo { Log = "Tiempo de eliminación: " + temporizador.Elapsed });
                    return RedirectToAction("Index");
                }
                catch
                {
                    temporizador.Stop();
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

        [HttpPost]
        public ActionResult BuscarNombre(string text)
        {

            Jugador j1 = new Jugador { Nombre = text };
            return Buscar(Jugador.CompararNombre, Igual, j1);
        }
        public ActionResult BuscarApellido(string text)
        {
            //apellido = "ewe";
            Jugador j1 = new Jugador { Apellido = text };
            return Buscar(Jugador.CompararApellido, Igual, j1);
        }
        public ActionResult BuscarPosicion(string text)
        {

            Jugador j1 = new Jugador { Posición = text };
            return Buscar(Jugador.CompararPosicion, Igual, j1);
        }

        public ActionResult BuscarSalarioMenor(string text)
        {
            Jugador j1 = new Jugador { Salario = double.Parse(text) };
           
                return Buscar(Jugador.CompararSalario, Menor, j1);
        }
        public ActionResult BuscarSalarioMayor(string text)
        {
            Jugador j1 = new Jugador { Salario = double.Parse(text) };
            
                return Buscar(Jugador.CompararSalario, Mayor, j1);
        }
        public ActionResult BuscarSalarioIgual(string text)
        {
            Jugador j1 = new Jugador { Salario = double.Parse(text) };
           
                return Buscar(Jugador.CompararSalario, Igual, j1);
        }

        public ActionResult BuscarClub(string text)
        {
            //nombre = "ewe";
            Jugador j1 = new Jugador { Club = text };
            return Buscar(Jugador.CompararClub, Igual, j1);
        }

        public ActionResult Buscar(Comparison<Jugador> parametro, Condition position, Jugador j1)
        {
            Stopwatch temporizador = new Stopwatch();
            temporizador.Start();
            if (Storage.Instance.EnListaEnlazada)
            {
                Storage.Instance.resultadosListaEnlazada.Clear();
                for (int i = 0; i < Storage.Instance.JugadorListaEnlazada.Count; i++)
                {
                    if (position.Invoke(parametro.Invoke(Storage.Instance.JugadorListaEnlazada.Get(i), j1)))
                    {
                        Storage.Instance.resultadosListaEnlazada.Add(Storage.Instance.JugadorListaEnlazada.Get(i));
                    }
                }
            }
            else
            {
                Storage.Instance.resultadosBusqueda.Clear();
                for (int i = 0; i < Storage.Instance.JugadorList.Count; i++)
                {
                    if (position.Invoke(parametro.Invoke(Storage.Instance.JugadorList[i], j1)))
                    {
                        Storage.Instance.resultadosBusqueda.Add(Storage.Instance.JugadorList[i]);
                    }
                }
            }
            temporizador.Stop();
            Storage.Instance.Log.Add(new Tiempo { Log = "Tiempo de búsqueda: " + temporizador.Elapsed });
            return RedirectToAction("Listas");
        }

        [HttpPost]
        public ActionResult AbrirArchivo(HttpPostedFileBase file)
        {
            Stopwatch temporizador = new Stopwatch();
            temporizador.Start();
            StreamReader stream = new StreamReader(file.InputStream);
            string text = stream.ReadToEnd();
            stream.Close();
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
            temporizador.Stop();
            Storage.Instance.Log.Add(new Tiempo { Log = "Tiempo de carga: " + temporizador.Elapsed });
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

        public static Condition Igual = delegate (int x)
        {
            return x == 0;
        };

        public static Condition Menor = delegate (int x)
        {
            return x < 0;
        };

        public static Condition Mayor = delegate (int x)
        {
            return x > 0;
        };
    }
}
