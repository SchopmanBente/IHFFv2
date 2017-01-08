using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;
using ProjectIHFFv2.Models.Repositories;

namespace ProjectIHFFv2.Controllers
{
    public class CartController : Controller
    {
        private PresentationViews presentation = new PresentationViews();
        private ICartRepository rep = new CartRepository(); 
        
        // GET: Cart
        public ActionResult Index()
        {
            //haal de sessie op
            List<ShoppingCartItem> lijst = HaalCartSessieOp();

            //vul de pagina met event gegevens in de sessie
           CartPresentationModel Model = presentation.FillPresentationModel(lijst); 


            return View(Model); 
        }

       


        public ActionResult Delete(int id)
        {
            //verwijder item uit sessie adhv eventid 
            presentation.VerwijderItem(id, HaalCartSessieOp());

            return RedirectToAction("Index"); 
        }

        public ActionResult Betaal()
        {
            //haal de sessie op
            List<ShoppingCartItem> lijst = HaalCartSessieOp();

            //vul checkoutmodel met juiste events
            CartPresentationModel reservingen = presentation.FillPresentationModel(lijst);

            CheckoutModel Model = new CheckoutModel(reservingen); 
            return View(Model); 
        }

        [HttpPost]
        public ActionResult Betaal(CheckoutModel model)
        {
            model.Reserveringen.Items = HaalCartSessieOp();
            model.Reserveringen.TotaalPrijs = rep.GetTotaalPrijs(model.Reserveringen.Items);
            
            if (ModelState.IsValid)
            {
                // redirect naar betaalpagina

                return View("ExterneBetaalpagina", model); 

            }


            return RedirectToAction("Betaal");
        }

        public ActionResult ExterneBetaalpagina(CheckoutModel model)
        {

            model.Reserveringen.Items = HaalCartSessieOp();
            model.Reserveringen.TotaalPrijs = rep.GetTotaalPrijs(model.Reserveringen.Items);
            return View(model); 
        }
        [HttpPost]
        public ActionResult ExterneBetaalpagina(CheckoutModel model, int? leeg)
        {

            model.Reserveringen.Items = HaalCartSessieOp();
            model.Reserveringen.TotaalPrijs = rep.GetTotaalPrijs(model.Reserveringen.Items);
            return RedirectToAction("Afgerond", model);
            //hier word het model leeg
        }

        public ActionResult Afgerond(CheckoutModel model)
        {
            model.Reserveringen.Items = HaalCartSessieOp();
            model.Reserveringen.TotaalPrijs = rep.GetTotaalPrijs(model.Reserveringen.Items); 
            
            bool bestaat = rep.BestaandeKlant(model.Email);

            if (!bestaat)
            {   //maak nieuwe klant in db
                Klant klant = new Klant(model.Email, model.VoorNaam, model.AchterNaam, model.TelefoonNummer);
                rep.AddKlant(klant);
                // haal aangemaakte klantid en maak reservering
                int klantid = rep.GetKlantId(model.Email);
                rep.AddReservering(klantid);
                // creeëer koppeling tussen reservering en klant in db
                rep.KoppelKlantReservering(klantid, model);

                return View();
            }

            else
            {
                int klantid = rep.GetKlantId(model.Email);
                rep.AddReservering(klantid);
                // creeëer koppeling tussen reservering en klant in db
                rep.KoppelKlantReservering(klantid, model);

                return View();
            }
             
        }

        private List<ShoppingCartItem> HaalCartSessieOp()
        {
            if (Session["cart"] == null)
            {   //maak nieuwe sessie als deze nog niet bestaat
                List<ShoppingCartItem> items = new List<ShoppingCartItem>();
                Session["cart"] = items;
                return items;
            }
            else
            {   //haal bestaande sessie op
                var cart = Session["cart"] as List<ShoppingCartItem>;
                List<ShoppingCartItem> items = (List<ShoppingCartItem>)cart;
                return items;
            }
        }
    }
}