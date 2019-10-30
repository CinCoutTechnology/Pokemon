using Pokemon2.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Pokemon2.Models;

namespace Pokemon2.Controllers
{
    public class EntrenadorController : Controller
    {
        PokemonContext context = new PokemonContext();
        // GET: Entrenador
        public ActionResult Index(string Palabra)
        {

            var entrenadores2 = context.Entrenadores.Include(o =>o.Ciudad).Include(o=> o.Relacion.Select(p =>p.Pokemon)).AsQueryable();

            if (!string.IsNullOrEmpty(Palabra))
                entrenadores2 = entrenadores2.Where(o => o.Nombre.Contains(Palabra));
            

            return View("Index",entrenadores2);
        }
        public ViewResult EntrenadorTabla(string Palabra)
        {
            var entrenadores2 = context.Entrenadores.Include(o => o.Ciudad).Include(o => o.Relacion.Select(p => p.Pokemon)).AsQueryable();

            if (!string.IsNullOrEmpty(Palabra))
                entrenadores2 = entrenadores2.Where(o => o.Nombre.Contains(Palabra));

            return View(entrenadores2);
        }
        [HttpGet]
        public ViewResult Guardar()
        {
            listadeCiudades();
            return View("Guardar");
        }
        [HttpPost]
        public ActionResult Guardar(Entrenador entrenador)
        {
            listadeCiudades();
            if (String.IsNullOrEmpty(entrenador.Nombre))
                ModelState.AddModelError("Nombre", "Es obligatorio");

            if (!ModelState.IsValid)
                return View("Guardar", entrenador);

            context.Entrenadores.Add(entrenador);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
        public void listadeCiudades()
        {
            ViewBag.Ciudad = context.Ciudad;
        }

        [HttpGet]
        public ViewResult GuardarPokemonEntrenador(int IdEntrenador)
        {
            var entrenador = context.Entrenadores.Where(a => a.IdEntrenador == IdEntrenador).FirstOrDefault();

            ViewBag.Entrenador = entrenador;

            var pokemones = context.Pokemones;

            ViewBag.pokemones = pokemones;

            ViewBag.Num = 1;
            return View("GuardarPokemonEntrenador", new RelacionEntradorPokemon());
        }

        [HttpPost]
        public ActionResult GuardarPokemon(Entrenador entrenador, List<RelacionEntradorPokemon> pokemon)
        {
            var identrenador =  entrenador.IdEntrenador;

            foreach(var lis in pokemon)
            {
                lis.EntrenadorId = identrenador;

                context.RelacionEntradorPokemones.Add(lis);
                context.SaveChanges();
            }
          return  RedirectToAction("Index");
        }
        
        public ActionResult ItemPokemon(int IdEntrenador, int index)
        {
            var pkemon = context.Pokemones.Where(a => a.IdPokemon == IdEntrenador).FirstOrDefault();

            ViewBag.Index = index;
          
            return View(pkemon);
        }
        public RedirectToRouteResult Eliminar(int IdPokemonId,int IdEntrenador)
        {
            var pokemon = context.RelacionEntradorPokemones.Where(a => a.PokemonId == IdPokemonId && a.EntrenadorId == IdEntrenador);

            context.RelacionEntradorPokemones.RemoveRange(pokemon);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}