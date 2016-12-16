using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Controllers
{
    public class SpecialController : Controller
    {
        //
        // GET: /Special/
        private SpecialRepository specialRepository = new SpecialRepository();
        private PresentationViews presentation = new PresentationViews();

        public ActionResult Woensdag()
        {
            IEnumerable<SpecialOverviewPresentationModel> specials = presentation.GetAllSpecialsForDay(new DateTime(2017, 1, 11, 00, 00, 00));
            return View(specials);
        }

        public ActionResult Donderdag()
        {
            IEnumerable<SpecialOverviewPresentationModel> specials = presentation.GetAllSpecialsForDay(new DateTime(2017, 1, 12, 00, 00, 00));
            return View(specials);
        }

        public ActionResult Vrijdag()
        {
            IEnumerable<SpecialOverviewPresentationModel> specials = presentation.GetAllSpecialsForDay(new DateTime(2017, 1, 13, 00, 00, 00));
            return View(specials);
        }

        public ActionResult Zaterdag()
        {
            IEnumerable<SpecialOverviewPresentationModel> specials = presentation.GetAllSpecialsForDay(new DateTime(2017, 1, 14, 00, 00, 00));
            return View(specials);
        }

        public ActionResult Zondag()
        {
            IEnumerable<SpecialOverviewPresentationModel> specials = presentation.GetAllSpecialsForDay(new DateTime(2017, 1, 15, 00, 00, 00));
            return View(specials);
        }

        public ActionResult ViewDetails()
        {
            return View();
        }


	}
}