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
    public class PokemonController : Controller
    {
        PokemonContext context = new PokemonContext();
        // GET: Pokemon
        public ActionResult Index(string criterio)
        {
            var listPokemones = context.Pokemones.Include(a => a.TipoPokemon);

            return View("Index",listPokemones);
        }
        [HttpGet]
        public ViewResult Guardar()
        {
            ViewBag.Tipo = context.TipoPokemones;

            return View("Guardar", new Pokemon());
        }
       [HttpPost]
        public ActionResult Guardar(Pokemon pokemon)
        {
         
           return RedirectToAction("Index", "Entrenador");
        }
    }
}