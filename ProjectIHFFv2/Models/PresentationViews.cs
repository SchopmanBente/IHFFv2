using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectIHFFv2.Models
{
    public class PresentationViews
    {
        private CultuurRepository cultuurRepository = new CultuurRepository();
        private FilmRepository filmRepository = new FilmRepository();
        private SpecialRepository specialRepository = new SpecialRepository();
        private LocatieRepository locatieRepository = new LocatieRepository();
        private RestaurantRepository restaurantRepository = new RestaurantRepository();

        public IEnumerable<FilmOverviewPresentationModel> GetAllFilmsForDay(DateTime day)
        {
            IEnumerable<Film> movies = filmRepository.GetAllForDay(day);
            List<FilmOverviewPresentationModel> moviePresentations = new List<FilmOverviewPresentationModel>();
            foreach (Film f in movies)
            {
                FilmOverviewPresentationModel moviePresentation = new FilmOverviewPresentationModel(f.EventId, f.naam, f.Event.afbeelding_url, f.Event.begin_datumtijd, f.Event.Locatie.naam, f.Event.Locatie.zaal, f.Event.beschrijving);
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
                SpecialOverviewPresentationModel specialPresentation = new SpecialOverviewPresentationModel(s.EventId,s.Event.naam,s.spreker, s.Event.afbeelding_url, s.Event.begin_datumtijd, s.Event.Locatie.naam, s.Event.Locatie.zaal, s.Event.beschrijving);
                specialPresentations.Add(specialPresentation);
            }
            return specialPresentations.AsEnumerable();
        }

        public FilmDetailPresentationModel GetFilmDetails(int id)
        {
            Film f = filmRepository.GetById(id);
            IEnumerable<Film> voorstellingenFilm = filmRepository.GetAllEventsForDetail(f.naam);
            IEnumerable<Cultuuritem> cultuurActiviteiten = cultuurRepository.GetRandomCultuurItems();
            FilmDetailPresentationModel model = new FilmDetailPresentationModel(f.EventId, f.naam, f.Event.afbeelding_url, f.trailer_url, f.Event.begin_datumtijd, f.Event.eind_datumtijd, f.Event.Locatie.naam, f.Event.Locatie.zaal, f.Event.beschrijving, cultuurActiviteiten, voorstellingenFilm);
            return model;          
        }

        public SpecialDetailPresentationModel GetSpecialDetails(int id)
        {
            Special s = specialRepository.GetSpecialById(id);
            IEnumerable<Event> restaurants = restaurantRepository.GetRandomRestaurants();
            Locatie locatie = locatieRepository.GetById(s.Event.Locatie.id);
            SpecialDetailPresentationModel special = new SpecialDetailPresentationModel(s.EventId, s.Event.naam, s.Event.Special.spreker, s.Event.afbeelding_url, s.Event.begin_datumtijd, s.Event.eind_datumtijd, locatie, s.Event.beschrijving, restaurants);
            return special;
        }
    }
}