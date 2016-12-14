using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Controllers
{
    public class FilmController : Controller
    {
        //
        // GET: /Film/
        private FilmRepository filmrepository = new FilmRepository();

        public ActionResult Woensdag()
        {
            IEnumerable<Film> films = filmrepository.GetAllForWednesday();
            return View(films);
        }

        public ActionResult Donderdag()
        {
            IEnumerable<Film> films = filmrepository.GetAllForThursday();
            return View(films);
        }

        public ActionResult Vrijdag()
        {
            IEnumerable<Film> films = filmrepository.GetAllForFriday();
            return View(films);
        }

        public ActionResult Zaterdag()
        {
            IEnumerable<Film> films = filmrepository.GetAllForSaturday();
            return View(films);
        }

        public ActionResult Zondag()
        {
            IEnumerable<Film> films = filmrepository.GetAllForSunday();
            return View(films);
        }
	}
}