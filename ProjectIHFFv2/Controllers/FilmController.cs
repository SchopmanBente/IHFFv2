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
            IEnumerable<Film> films = filmrepository.GetAllForDay( new DateTime(2017, 1, 11, 00, 00, 00));
            return View(films);
        }

        public ActionResult Donderdag()
        {
            IEnumerable<Film> films = filmrepository.GetAllForDay(new DateTime(2017, 1, 12, 00, 00, 00));
            return View(films);
        }

        public ActionResult Vrijdag()
        {
            IEnumerable<Film> films = filmrepository.GetAllForDay(new DateTime(2017, 1, 13, 00, 00, 00));
            return View(films);
        }

        public ActionResult Zaterdag()
        {
            IEnumerable<Film> films = filmrepository.GetAllForDay(new DateTime(2017, 1, 14, 00, 00, 00));
            return View(films);
        }

        public ActionResult Zondag()
        {
            IEnumerable<Film> films = filmrepository.GetAllForDay(new DateTime(2017, 1, 15, 00, 00, 00));
            return View(films);
        }
	}
}