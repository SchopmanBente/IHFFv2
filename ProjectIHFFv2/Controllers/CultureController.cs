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
    }
}