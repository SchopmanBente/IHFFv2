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
        private PresentationViews presentation = new PresentationViews();

        public ActionResult Woensdag()
        {
            IEnumerable<FilmOverviewPresentationModel> films = presentation.GetAllFilmsForDay(new DateTime(2017, 1, 11, 00, 00, 00));
            return View(films);
        }

        public ActionResult Donderdag()
        {
            IEnumerable<FilmOverviewPresentationModel> films = presentation.GetAllFilmsForDay(new DateTime(2017, 1, 12, 00, 00, 00));
            return View(films);
        }

        public ActionResult Vrijdag()
        {
            IEnumerable<FilmOverviewPresentationModel> films = presentation.GetAllFilmsForDay(new DateTime(2017, 1, 13, 00, 00, 00));
            return View(films);
        }

        public ActionResult Zaterdag()
        {
            IEnumerable<FilmOverviewPresentationModel> films = presentation.GetAllFilmsForDay(new DateTime(2017, 1, 14, 00, 00, 00));
            return View(films);
        }

        public ActionResult Zondag()
        {
            IEnumerable<FilmOverviewPresentationModel> films = presentation.GetAllFilmsForDay(new DateTime(2017, 1, 15, 00, 00, 00));
            return View(films);
        }

        public ActionResult ViewDetails(int id)
        {
            FilmDetailPresentationModel filmDetail = presentation.GetFilmDetails(id);
            return View(filmDetail);
        }
	}
}