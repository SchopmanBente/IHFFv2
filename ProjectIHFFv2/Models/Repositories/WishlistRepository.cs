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
            List<WishlistItem> wishlist = Session["wishlist"] as List<WishlistItem>;
            DateTime standaardTijd = new DateTime(2017, 1, 11, 11, 00, 00);
            //MAAK EEN ARRAY MET COORDINATEN EN NEEM VAN DE COORDINAAT DE EERSTE WAARDE BOVENAAN EN DE EERSTE WAARDE LINKS. MAAK HIER EEN DATETIME VAN.
            string[,] tijdNavigatieArray = MakeTimeArray();
            int x = 0;
            int y = 0;
            foreach (WishlistItem item in wishlist)
            {
                string heleDatum = item.beginTijd.ToString();
                string tijd = heleDatum.Substring(0, 8);
                string datum = heleDatum.Substring(10, 14);

                while (x < 24) //30 kan vgm nog lager...
                {
                    if (tijd == tijdNavigatieArray[x, 0])
                    {
                        item.xCoordinaat = x;
                    }
                    x++;
                }

                while (y < 5)
                {
                    if (datum == tijdNavigatieArray[0, y])
                    {
                        item.yCoordinaat = y;
                    }
                    y++;
                }

                //colspan berekenen
                DateTime DatumTijd = Convert.ToDateTime(tijdNavigatieArray[0, item.yCoordinaat] + tijdNavigatieArray[item.xCoordinaat, 0]);
                string tijdsduur = (item.eindTijd - item.beginTijd).ToString(); //krijg het verschil in tijd te zien.
                int uren = Int32.Parse(tijdsduur.Substring(2));
                int minuten = Int32.Parse(tijdsduur.Substring(4, 5));
                int totaalminuten = (uren * 60) + minuten;
                item.colspan = totaalminuten / 30;
            }

            //Van alle tijden die er zijn is er nu een tijd ingevuld. Bij de tabelcreatie wordt een if (!null) gebruikt.

            return wishlist;
        }

        public string[,] MakeTimeArray() //maak array 1x
        {
            if (gemaakteArray == null) //als deze array al een gemaakt is returnt hij de gemaakte array meteen.
            {
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


                    if (x == 24)
                    {
                        gemaakteArray[0, 1] = "11/01/2017";
                        gemaakteArray[0, 2] = "12/01/2017";
                        gemaakteArray[0, 3] = "13/01/2017";
                        gemaakteArray[0, 4] = "14/01/2017";
                        gemaakteArray[0, 5] = "15/01/2017";
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

        public void AddToWishlist(Event item, int aantal,List<WishlistItem> items)
        {
            //voeg item toe aan session die een lijst van wishlistmodels bevat.
            WishlistItem wishlistItem = new WishlistItem();
            wishlistItem.aantal = aantal;
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