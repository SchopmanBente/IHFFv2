using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class PresentationViews
    {
        private CultuurRepository cultuurRepository = new CultuurRepository();
        private CartRepository cartRepository = new CartRepository();
        private EventRepository eventRepository = new EventRepository();
        private FilmRepository filmRepository = new FilmRepository();
        private SpecialRepository specialRepository = new SpecialRepository();
        private RestaurantRepository restaurantRepository = new RestaurantRepository();
        private LocatieRepository locatieRepository = new LocatieRepository();
        private WishlistRepository wishlistRepository = new WishlistRepository();
      

        public IEnumerable<FilmOverviewPresentationModel> GetAllFilmsForDay(DateTime day)
        {
            IEnumerable<Film> movies = filmRepository.GetAllForDay(day);
            List<FilmOverviewPresentationModel> moviePresentations = new List<FilmOverviewPresentationModel>();
            foreach (Film f in movies)
            {
                Locatie locatie = locatieRepository.GetById(f.Event.Locatie.id);
                FilmOverviewPresentationModel moviePresentation = new FilmOverviewPresentationModel(f.EventId, f.naam, f.Event.afbeelding_url, f.Event.begin_datumtijd, f.Event.eind_datumtijd,locatie, f.Event.beschrijving);
                moviePresentations.Add(moviePresentation);
            }
            return moviePresentations.AsEnumerable();
        }

        public IEnumerable<SpecialOverviewPresentationModel> GetAllSpecialsForDay(DateTime day)
        {
            IEnumerable<Special> specials = specialRepository.GetAllForDay(day);
            List<SpecialOverviewPresentationModel> specialPresentations = new List<SpecialOverviewPresentationModel>();
            foreach (Special s in specials)
            {
                SpecialOverviewPresentationModel specialPresentation = new SpecialOverviewPresentationModel(s.EventId, (double)s.Event.prijs, s.Event.naam, s.spreker, s.Event.afbeelding_url, s.Event.begin_datumtijd, s.Event.Locatie.naam, s.Event.Locatie.zaal, s.Event.beschrijving);
                specialPresentations.Add(specialPresentation);
            }
            return specialPresentations.AsEnumerable();
        }

        public FilmDetailPresentationModel GetFilmDetails(int id)
        {
            //Haal de film op
            Film f = filmRepository.GetById(id);
            //Haal de voorstellingen van de film op
            IEnumerable<Film> voorstellingenFilm = filmRepository.GetAllEventsForDetail(f.naam);
            //Haal culturele activiteiten op
            IEnumerable<Cultuuritem> cultuurActiviteiten = cultuurRepository.GetRandomCultuurItems();
            //Creer een model
            FilmDetailPresentationModel model = new FilmDetailPresentationModel(f.EventId, f.naam, f.Event.afbeelding_url, f.trailer_url, f.Event.begin_datumtijd, f.Event.eind_datumtijd, f.Event.Locatie.naam, f.Event.Locatie.zaal, f.Event.beschrijving, cultuurActiviteiten,voorstellingenFilm);
            return model;
        }

        public RestaurantDetailPresentationModel GetRestaurantDetails(int id)
        {
            List<Film> films = (List<Film>)filmRepository.GetRandomFilms();
            Event Event = restaurantRepository.GetRestaurantByid(id);
            RestaurantDetailPresentationModel model = new RestaurantDetailPresentationModel(films, Event);

            return model;

        }

        public SpecialDetailPresentationModel GetSpecialDetails(int id)
        {
            Special s = specialRepository.GetSpecialById(id);
            IEnumerable<Event> restaurants = restaurantRepository.GetRandomRestaurants();
            Locatie locatie = locatieRepository.GetById(s.Event.Locatie.id);
            SpecialDetailPresentationModel special = new SpecialDetailPresentationModel(s.EventId,(double)s.Event.prijs,s.Event.naam, s.Event.Special.spreker, s.Event.afbeelding_url, s.Event.begin_datumtijd, s.Event.eind_datumtijd, locatie, s.Event.beschrijving, restaurants);
            return special;
        }

        public void AddToWishlist(int aantalPersonen, int eventId, List<WishlistItem> items) 
        {
            Event gebeurtenis = eventRepository.GetById(eventId); 
            wishlistRepository.AddToWishlist(gebeurtenis, aantalPersonen, (DateTime)gebeurtenis.begin_datumtijd,items);

        }

        public void AddToCart(int aantalPersonen, int eventId, List<ShoppingCartItem> items)
        {
            Event gebeurtenis = eventRepository.GetById(eventId);
            cartRepository.AddEventToCart(gebeurtenis, aantalPersonen, items);
        }
    }
}