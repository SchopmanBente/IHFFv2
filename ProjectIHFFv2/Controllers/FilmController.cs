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
            IEnumerable<Film> films = filmrepository.GetAll();
            return View(films);
        }
	}
}