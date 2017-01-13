using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;
using ProjectIHFFv2.Models.Repositories;

namespace ProjectIHFFv2.Controllers
{
    public class CultureController : Controller
    {
        ICultuurRepository cultuurRepository = new CultuurRepository();

        public ActionResult monument()
        {
            return View(cultuurRepository.GetMonuments());
        }

        public ActionResult museum()
        {
            return View(cultuurRepository.GetMuseums());
        }

        public ActionResult music()
        {
            return View(cultuurRepository.GetMusics());
        }

        public ActionResult ViewDetails(int? id)
        {
            if (id != null) //als de int null is (direct naar de pagina zonder een id) wordt de gebruiker naar de detailpagina gelinkt.
            {
                //Alles in de culturepresentationmodel doen.
                Cultuuritem ViewDetailsCultuurItem = cultuurRepository.GetCultuurItem(id);
                IEnumerable<Cultuuritem> randomCultuurItems = cultuurRepository.GetRandomCultuurItems();
                IEnumerable<Film> randomFilms = cultuurRepository.GetRandomFilms();
                CulturePresentationModel cultuurPresentatieModel = new CulturePresentationModel(ViewDetailsCultuurItem, randomCultuurItems, randomFilms);
                return View(cultuurPresentatieModel);
            }

                return RedirectToAction("monument","Culture");
            
        }

        public ActionResult ViewRoute()
        {
            return View();
        }
    }
}