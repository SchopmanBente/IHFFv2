using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectIHFFv2.Models;
using ProjectIHFFv2.Models.Repositories;

namespace ProjectIHFFv2.Models
{
    public class WishlistRepository : IWishlistRepository
    {

        public bool AddToWishlist(Event item, int aantal, List<WishlistItem> items)
        {
            int aantalTrue = 0; //houdt bij hoeveel keer er false is teruggegeven op de vraag: Is de datum en tijd al in gebruik?
            foreach (WishlistItem bestaandItem in items)
            {
                if (bestaandItem.beginTijd.Day == item.begin_datumtijd.Day) //deze if heeft geen else, ga als false gewoon naar de volgende bestaandItem
                {
                    if (item.begin_datumtijd >= bestaandItem.eindTijd || item.eind_datumtijd <= bestaandItem.beginTijd) //check of de tijd al in gebruik is, als dat zo is wordt er false ge returnt.
                    {
                        aantalTrue++;
                    }
                }
                else
                {
                    aantalTrue++; //De tijd kan niet in gebruik zijn wanneer het op een andere dag is...
                }
            }

            if (aantalTrue == items.Count) //Check of de tijd van alle events niet botsen met de tijd van het toe te voegen event
            {
                //Zet Event om in WishlistItem en voeg deze toe aan de wishlist
                WishlistItem wishlistItem = new WishlistItem();
                wishlistItem.aantal = aantal;
                wishlistItem.beginTijd = item.begin_datumtijd;
                wishlistItem.eindTijd = item.eind_datumtijd;
                wishlistItem.EventId = item.EventId;
                wishlistItem.locatieId = item.locatie_id;
                wishlistItem.naam = item.naam;
                wishlistItem.prijs = item.prijs * aantal;
                wishlistItem.type = item.type;
                if (!items.Exists(w => w.EventId == item.EventId))
                {
                    items.Add(wishlistItem);
                    return true;
                }
                return false;
            }
            else
            {
                return false;
            }
        }


        public void RemoveFromWishlist(int id, List<WishlistItem> wishlistSession)
        {
            WishlistItem teVerwijderen = wishlistSession.Single(i => i.EventId == id); //Zoek te verwijderen item op
            wishlistSession.Remove(teVerwijderen); //Verwijder dit item.
        }

        public List<WishlistItem> MakeWishlist(List<WishlistItem> meegekregenWishlist)
        {
            List<WishlistItem> wishlist = meegekregenWishlist;
            string[,] tijdNavigatieArray = MakeTimeArray();

            foreach (WishlistItem item in wishlist)
            {
                int x = 0;
                int y = 0;
                string heleDatum = item.beginTijd.ToString("dd'/'MM'/'yyyy HH:mm");
                string datum = heleDatum.Substring(0, 10);
                string tijd = heleDatum.Substring(11, 5);
                //Checken waar de datum hoort in het tabel (geef dit item een x en y coördinaat)
                if (heleDatum != "Datum is null") 
                {
                    while (x < 28)
                    {
                        if (tijd == tijdNavigatieArray[x, 0])
                        {
                            item.xCoordinaat = x;
                        }
                        x++;
                    }

                    while (y < 6)
                    {
                        if (datum == tijdNavigatieArray[0, y])
                        {
                            item.yCoordinaat = y;
                        }
                        y++;
                    }
                    //colspan berekenen
                    if ((item.yCoordinaat != 0) && (item.xCoordinaat != 0))
                    {
                        string tijdsduur = (item.eindTijd - item.beginTijd).ToString(); //krijg het verschil in tijd te zien.
                        int uren = Int32.Parse(tijdsduur.Substring(0, 2));
                        int minuten = Int32.Parse(tijdsduur.Substring(3, 2));
                        int totaalminuten = (uren * 60) + minuten;
                        item.colspan = totaalminuten / 30;
                    }
                }//einde aan if (heleDatum == "Datum is null")
            }
            //Van alle tijden die er zijn is er nu een tijd ingevuld.
            return wishlist;
        }

        private string[,] MakeTimeArray() //maak array 1x
        {
            string[,] gemaakteArray = new string[28, 6]; //Standaardwaarden voor de tijden die iHff heeft. 27 mogelijke tijden en 5 dagen.
            int x = 0;
            int y = 0;
            string tijd = "11:00"; //Eerste tijd waarop het iHff Festival kan beginnen
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
                        if (tijd == "24:00")
                        {
                            gemaakteArray[x, y] = "00:00";
                        }
                        gemaakteArray[x, y] = tijd;
                        tijd = uur.ToString() + ":30";

                    }
                } //alle tijden zijn toegevoegd, nu de dagen nog.
                if (x == 27)
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
    }
}