using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectIHFFv2.Models;

namespace ProjectIHFFv2.Models.Repositories
{
  public interface IRestaurantRepository
    {
        IEnumerable<Event> GetRestaurantsByPlaatsnaam(string plaatsnaam);

        Event GetRestaurantByid(int? id);

        IEnumerable<Event> GetRandomRestaurants();

        IEnumerable<Event> GetAllMaaltijdenForDetail(string naam);


    }
}
