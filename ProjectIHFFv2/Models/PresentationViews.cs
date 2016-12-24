using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class PresentationViews
    {
        //Alle repositories
        private CultuurRepository cultuurRepository = new CultuurRepository();
        private CartRepository cartRepository = new CartRepository();
        private IEventRepository eventRepository = new EventRepository();
        private IFilmRepository filmRepository = new FilmRepository();
        private ISpecialRepository specialRepository = new SpecialRepository();
        private RestaurantRepository restaurantRepository = new RestaurantRepository();
        private ILocatieRepository locatieRepository = new LocatieRepository();
        private WishlistRepository wishlistRepository = new WishlistRepository();


        //Haalt films voor een bepaalde dag op
        public IEnumerable<FilmOverviewPresentationModel> GetAllFilmsForDay(DateTime day)
        {
            //Haal alle films voor een bepaalde dag uit de filmrepository
            IEnumerable<Film> movies = filmRepository.GetAllForDay(day);
            List<FilmOverviewPresentationModel> moviePresentations = new List<FilmOverviewPresentationModel>();
            //Zet elke film om in een FilmOverviewPresentationModel
            foreach (Film f in movies)
            {
                Locatie locatie = locatieRepository.GetById(f.Event.Locatie.id);
                FilmOverviewPresentationModel moviePresentation = new FilmOverviewPresentationModel(f.EventId, f.naam,(double)f.Event.rating,f.Event.afbeelding_url, f.Event.begin_datumtijd, f.Event.eind_datumtijd, locatie, f.Event.beschrijving);
                moviePresentations.Add(moviePresentation);
            }
            //Return de list as Enumerable
            return moviePresentations.AsEnumerable();
        }

        //Haalt alle specials voor een bepaalde dag op
        public IEnumerable<SpecialOverviewPresentationModel> GetAllSpecialsForDay(DateTime day)
        {
            //Haal alle specials op voor een bepaalde dag
            IEnumerable<Special> specials = specialRepository.GetAllForDay(day);
            List<SpecialOverviewPresentationModel> specialPresentations = new List<SpecialOverviewPresentationModel>();
            //Zet elke special om in een specialoverviewPresentationModel
            foreach (Special s in specials)
            {
                SpecialOverviewPresentationModel specialPresentation = new SpecialOverviewPresentationModel(s.EventId,(double)s.Event.prijs, s.Event.naam, s.spreker, s.Event.afbeelding_url, s.Event.begin_datumtijd, s.Event.Locatie.naam, s.Event.Locatie.zaal, s.Event.beschrijving);
                specialPresentations.Add(specialPresentation);
            }
            return specialPresentations.AsEnumerable();
        }

        public FilmDetailPresentationModel GetFilmDetails(int id)
        {
            //Haal de film op
            Film f = filmRepository.GetById(id);
            //Haal de voorstellingen van de film op
             IEnumerable<Film>   voorstellingenFilm = filmRepository.GetAllEventsForDetail(f.naam);
            //Haal culturele activiteiten op
            IEnumerable<Cultuuritem> cultuurActiviteiten = cultuurRepository.GetRandomCultuurItems();
            //Creer een model
            FilmDetailPresentationModel model = new FilmDetailPresentationModel(f.EventId, f.naam, (double)f.Event.rating, f.Event.afbeelding_url, f.trailer_url, f.Event.begin_datumtijd, f.Event.eind_datumtijd, f.Event.Locatie.naam, f.Event.Locatie.zaal, f.Event.beschrijving, cultuurActiviteiten, voorstellingenFilm);
            return model;
        }

        public RestaurantDetailPresentationModel GetRestaurantDetails(int id)
        {
            List<Film> films = (List<Film>)filmRepository.GetRandomFilms();

            Event Event = restaurantRepository.GetRestaurantByid(id);
            IEnumerable<Event> allemaaltijden = restaurantRepository.GetAllMaaltijdenForDetail(Event.naam);

            RestaurantDetailPresentationModel model = new RestaurantDetailPresentationModel(films, Event, allemaaltijden.ToList());

            return model;

        }

        //Haal alle details voor een special op
        public SpecialDetailPresentationModel GetSpecialDetails(int id)
        {
            //Haal alle informatie voor een special op uit de database
            Special s = specialRepository.GetSpecialById(id);
            //Genereer een lijst van random restaurants
            IEnumerable<Event> restaurants = restaurantRepository.GetRandomRestaurants();
            //Haal de locatie op van het event
            Locatie locatie = locatieRepository.GetById(s.Event.Locatie.id);
            //Zet de Special om in een SpecialDetailPresentationModel
            SpecialDetailPresentationModel special = new SpecialDetailPresentationModel(s.EventId, (double)s.Event.prijs,s.Event.naam, s.Event.Special.spreker, s.Event.afbeelding_url, s.Event.begin_datumtijd, s.Event.eind_datumtijd, locatie, s.Event.beschrijving, restaurants);
            return special;
        }
        public void AddToWishlist(int aantalPersonen, int eventId, List<WishlistItem> items)
        {
            //Haal het event op uit de eventrepository
            Event gebeuren = eventRepository.GetById(eventId);
            //Voeg het toe aan de wishlistRepository
            wishlistRepository.AddToWishlist(gebeuren, aantalPersonen, items);
        }

        public void AddToCart(int aantalPersonen, int eventId, List<ShoppingCartItem> items)
        {
            //Haal het event op de uit de eventrepository
            Event gebeurtenis = eventRepository.GetById(eventId);
            //Voeg het toe aan de cart
            cartRepository.AddEventToCart(gebeurtenis, aantalPersonen, items);

            
        }

     public List<ShoppingCartItem> VerwijderItem(int id, List<ShoppingCartItem> lijst)
        {
           lijst = cartRepository.RemoveFromCart(id, lijst);

            return lijst; 
        }

        public IEnumerable<RestaurantOverviewPresentationModel> GetAllRestaurantsByLocation(string locatie)
        {
            IEnumerable<Event> restaurants = restaurantRepository.GetRestaurantsByPlaatsnaam(locatie);

            List<RestaurantOverviewPresentationModel> resPresentLijst = new List<RestaurantOverviewPresentationModel>();

            foreach (Event r in restaurants)
            {
                RestaurantOverviewPresentationModel resOverviewModel = new RestaurantOverviewPresentationModel(r);
                resPresentLijst.Add(resOverviewModel);
            }

            return resPresentLijst.AsEnumerable();
        }

        public CartPresentationModel FillPresentationModel(List<ShoppingCartItem> Items)
        {
            double totaalPrijs = cartRepository.GetTotaalPrijs(Items);
            CartPresentationModel Model = new CartPresentationModel(Items, totaalPrijs);

            return Model;

        }

      
    }


}