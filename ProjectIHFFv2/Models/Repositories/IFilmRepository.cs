using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIHFFv2.Models
{
    interface IFilmRepository
    {
        IEnumerable<Film> GetAllForDay(DateTime dag);
        IEnumerable<Film> GetAllEventsForDetail(string naam);
        Film GetById(int id);
        IEnumerable<Film> GetRandomFilms();
    }
}
