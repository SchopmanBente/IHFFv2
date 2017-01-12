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

            if (Model.Reserveringen.Items.Count > 0 && Model.Email != "")
                return View(Model);

            else
                return RedirectToAction("Index", "Home");
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


            return RedirectToAction("Afgerond", model);
        }

        public ActionResult Afgerond(CheckoutModel model)
        {
            List<ShoppingCartItem> lijst = HaalCartSessieOp();

            //vul checkoutmodel met juiste events
            CartPresentationModel reservingen = presentation.FillPresentationModel(lijst);
            //vul model opnieuw met juiste reserveringen
            model.Reserveringen = reservingen;

            //maak er een afgeronde bestelling van
            AfgerondeBestelling Bestelling = rep.CheckoutToBestelling(model);

            //kijk of de gewenste capaciteit beschikbaar is
            if (rep.ChangeCapacity(Bestelling))
            {
                bool bestaat = rep.BestaandeKlant(Bestelling.Klant.emailadres);

                if (!bestaat)
                {   //maak nieuwe klant in db

                    rep.AddKlant(Bestelling.Klant);
                    // haal aangemaakte klantid en maak reservering
                    int klantid = rep.GetKlantId(Bestelling.Klant.emailadres);
                    rep.AddReservering(klantid);
                    // creeëer koppeling tussen reservering en klant in db
                    rep.KoppelKlantReservering(klantid, Bestelling);



                    //voeg de gegenereerde ophaalcode toe aan de bestelling voor weergave op de view
                    Bestelling.ophaalcode = rep.GetOphaalCode(rep.GetReserveringId(klantid));
                    
                }

                else
                { //haal klantid op om nieuwe reservering te maken
                    int klantid = rep.GetKlantId(Bestelling.Klant.emailadres);
                    rep.AddReservering(klantid);
                    // creeëer koppeling tussen reservering en klant in db
                    rep.KoppelKlantReservering(klantid, Bestelling);
                    Bestelling.ophaalcode = rep.GetOphaalCode(rep.GetReserveringId(klantid));
                    
                }
                Session["cart"] = null;
                return View(Bestelling);
            }
            else
            { //capaciteit niet beschibkaar
                
                return RedirectToAction("BestellingMislukt");
            }



            

        }

        public ActionResult BestellingMislukt()
        {
            ModelState.AddModelError(string.Empty, "Unfortunately the capacity is exceeded, please check the items in your shopping cart and try again");
            return View();

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