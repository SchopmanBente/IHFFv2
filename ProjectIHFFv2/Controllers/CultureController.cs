using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Controllers
{
    public class CultureController : Controller
    {
        CultuurRepository cultuurRepository = new CultuurRepository();

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

        public ActionResult ViewDetails(int id)
        {
            Cultuuritem cultuurItem = cultuurRepository.GetCultuurItem(id);
            IEnumerable<Cultuuritem> randomCultuurItems = cultuurRepository.GetRandomCultuurItems();
            IEnumerable<Film> randomFilms = cultuurRepository.GetRandomFilms();
            CulturePresentationModel cultuurPresentatieModel = new CulturePresentationModel(cultuurItem, randomCultuurItems, randomFilms);
            return View(cultuurPresentatieModel);
        }

        public ActionResult ViewRoute()
        {
            return View();
        }
    }
}