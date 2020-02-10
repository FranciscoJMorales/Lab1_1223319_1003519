using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab1_1223319_1003519.Models;
using CustomGenerics.Estructuras;

namespace Lab1_1223319_1003519.Controllers
{
    public class JugadorController : Controller
    {
        // GET: Jugador
        public ActionResult Index()
        {
            var jugadores = new ListaEnlazada<Jugador>();
            jugadores.Add(new Jugador { Nombre = "Thomas", Apellido = "Müller", Posición = "Delantero", Salario = 1000000, Club = "Bayern" });
            jugadores.Add(new Jugador { Nombre = "Moyo", Apellido = "Contreras", Posición = "Mediocampista", Salario = 2000000, Club = "Comunicaciones" });
            jugadores.Add(new Jugador { Nombre = "Mynor", Apellido = "Crackpollo", Posición = "Delantero", Salario = 999999999, Club = "Mixco" });
            return View(jugadores);
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
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Jugador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Jugador/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
    }
}
