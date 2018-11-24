using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World
    {
        private List<Station> _Stations = new List<Station>();

        internal void AddStation(int id, string name, int posX, int posY, int level)
        {
            Station station = new Station(id, name, posX, posY, level);

            _Stations.Add(station);
        }

        public Station StationWithID(int id)
        {
            foreach (Station station in _Stations)
            {
                if (station.ID==id)
                {
                    return station;
                }
            }

            return null;
        }
    }
}
