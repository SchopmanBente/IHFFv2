using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Models
{
    public class WishlistRepository : Controller //:controller zodat de session gebruikt kan worden.
    {
        string[,] gemaakteArray = new string[20, 20];

        //Hier session of cookies pakken wanneer de 'database' aangeroepen wordt.
        public List<WishlistItem> GetWishlist()
        {
            List<WishlistItem> wishlist = Session["wishlist"] as List<WishlistItem>;
            //pak uit de session of cookie alle dingen die aan die hieraan zijn toegevoegd.
            return wishlist;
        }

        public List<WishlistItem> MakeWishlist()
        {
            List<WishlistItem> wishlist = new List<WishlistItem>();
            DateTime standaardTijd = new DateTime(2017, 1, 11, 11, 00, 00);
            //MAAK EEN ARRAY MET COORDINATEN EN NEEM VAN DE COORDINAAT DE EERSTE WAARDE BOVENAAN EN DE EERSTE WAARDE LINKS. MAAK HIER EEN DATETIME VAN.
            string[,] tijdNavigatieArray = MakeTimeArray();



            //Van alle tijden die er zijn is er nu een tijd ingevuld. Bij de tabelcreatie wordt een if (!null) gebruikt.

            return wishlist;
        }

        public string[,] MakeTimeArray() //maak array 1x
        {
            if (gemaakteArray == null) //als deze array al een gemaakt is returnt hij de gemaakte array meteen.
            {
                gemaakteArray[1, 0] = "11:00";
                gemaakteArray[2, 0] = "11:30";
                gemaakteArray[3, 0] = "12:00";
                gemaakteArray[4, 0] = "11:30";
                gemaakteArray[5, 0] = "13:00";
                gemaakteArray[6, 0] = "11:30";
                gemaakteArray[7, 0] = "14:00";
                gemaakteArray[8, 0] = "11:30";
                gemaakteArray[9, 0] = "15:00";
                gemaakteArray[10, 0] = "11:30";
                gemaakteArray[11, 0] = "16:00";
                gemaakteArray[12, 0] = "11:30";
                gemaakteArray[13, 0] = "12:00";
                gemaakteArray[14, 0] = "12:30";
                gemaakteArray[15, 0] = "13:00";
                gemaakteArray[16, 0] = "13:30";
                gemaakteArray[17, 0] = "14:00";
                gemaakteArray[18, 0] = "14:30";
                gemaakteArray[19, 0] = "15:00";
                gemaakteArray[20, 0] = "15:30";
                gemaakteArray[21, 0] = "16:00";
                gemaakteArray[22, 0] = "16:30";
                gemaakteArray[23, 0] = "17:00";
                gemaakteArray[24, 0] = "17:30";
                gemaakteArray[25, 0] = "18:00";
                gemaakteArray[26, 0] = "18:30";
                gemaakteArray[27, 0] = "18:00";
                gemaakteArray[28, 0] = "18:00";
                gemaakteArray[29, 0] = "18:00";
                gemaakteArray[30, 0] = "18:00";
                gemaakteArray[31, 0] = "18:00";
                gemaakteArray[32, 0] = "18:00";
                gemaakteArray[33, 0] = "18:00";
                gemaakteArray[34, 0] = "18:00";
                gemaakteArray[35, 0] = "18:00";
                gemaakteArray[36, 0] = "18:00";
                gemaakteArray[37, 0] = "18:00";
                gemaakteArray[38, 0] = "18:00";
                gemaakteArray[39, 0] = "18:00";
                gemaakteArray[25, 0] = "18:00";
                gemaakteArray[25, 0] = "18:00";


                int x = 0;
                int y = 0;
                string tijd = "11:00";
                int uur = 11;
                bool doorgaan = true;
                
                while (doorgaan)
                {
                    if (tijd != "24:30") //voeg alle tijden toe aan rij 0 van de array.
                    {
                        x++;
                        if (tijd.Contains("30"))
                        {
                            gemaakteArray[x, y] = tijd;
                            uur++;
                            tijd = uur.ToString() + ":00";
                        }
                        else
                        {
                            gemaakteArray[x, y] = tijd;
                            tijd = uur.ToString() + ":30";
                        }
                    } //alle tijden zijn toegevoegd, nu de dagen nog.




                    if (y == 5)
                    {
                        doorgaan = false;
                    }
                }

                return gemaakteArray;
            }
            else
            {
                return gemaakteArray;
            }
        }

        public void AddToWishlist(Event item, int aantal, DateTime tijd,List<WishlistItem> items)
        {
            //voeg item toe aan session die een lijst van wishlistmodels bevat.
            WishlistItem wishlistItem = new WishlistItem();
            wishlistItem.aantal = aantal;
            wishlistItem.EerstMogelijkeTijd = tijd;
            wishlistItem.beginTijd = item.begin_datumtijd;
            wishlistItem.eindTijd = item.eind_datumtijd;
            wishlistItem.EventId = item.EventId;
            wishlistItem.locatieId = item.locatie_id;
            wishlistItem.naam = item.naam;
            wishlistItem.prijs = item.prijs * aantal;
            wishlistItem.type = item.type;
            List<WishlistItem> wishlist = items;
            //List<WishlistItem> wishlist = Session["wishlist"] as List<WishlistItem>;
            wishlist.Add(wishlistItem);
        }

        public void RemoveFromWishlist(WishlistItem item)
        {
            List<WishlistItem> wishlist = Session["wishlist"] as List<WishlistItem>;
            foreach (WishlistItem wishlistItem in wishlist)
            {
                if (wishlistItem.EventId == item.EventId)
                {
                    wishlist.Remove(wishlistItem);
                }
            }
        }

        public void EditWishtlist(WishlistItem item)
        {

        }

    }
}