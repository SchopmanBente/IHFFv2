using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectIHFFv2.Models.Repositories
{
    public interface ICultuurRepository
    {
        IEnumerable<Cultuuritem> GetRandomCultuurItems();
        IEnumerable<Film> GetRandomFilms();
        IEnumerable<Cultuuritem> GetMonuments();
        IEnumerable<Cultuuritem> GetMuseums();
        IEnumerable<Cultuuritem> GetMusics();
        Cultuuritem GetCultuurItem(int id);
    }
}
