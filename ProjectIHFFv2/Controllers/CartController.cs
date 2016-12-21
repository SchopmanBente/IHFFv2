using System;
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