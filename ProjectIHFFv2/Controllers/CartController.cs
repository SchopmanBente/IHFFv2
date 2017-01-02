﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models; 

namespace ProjectIHFFv2.Controllers
{
    public class CartController : Controller
    {
        private PresentationViews presentation = new PresentationViews();
        
        // GET: Cart
        public ActionResult Index()
        {
            List<ShoppingCartItem> lijst = HaalCartSessieOp();

           CartPresentationModel Model = presentation.FillPresentationModel(lijst); 


            return View(Model); 
        }

       


        public ActionResult Delete(int id)
        {
            presentation.VerwijderItem(id, HaalCartSessieOp());

            return RedirectToAction("Index"); 
        }

        public ActionResult Betaal()
        {
            List<ShoppingCartItem> lijst = HaalCartSessieOp();

            CartPresentationModel reservingen = presentation.FillPresentationModel(lijst);

            CheckoutModel Model = new CheckoutModel(reservingen); 
            return View(Model); 
        }

        [HttpPost]
        public ActionResult Betaal(CheckoutModel model)
        {
            if(ModelState.IsValid)
            {
                // redirect naar betaalpagina
                RedirectToAction("Index", "Home"); 
            }


            return View("Betaal");
        }

        private List<ShoppingCartItem> HaalCartSessieOp()
        {
            if (Session["cart"] == null)
            {
                List<ShoppingCartItem> items = new List<ShoppingCartItem>();
                Session["cart"] = items;
                return items;
            }
            else
            {
                var cart = Session["cart"] as List<ShoppingCartItem>;
                List<ShoppingCartItem> items = (List<ShoppingCartItem>)cart;
                return items;
            }
        }
    }
}