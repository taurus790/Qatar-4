using Engine.Models.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Engine.Models
{
    public class World : BaseCsGameEntity
    {
        #region Private attributes

        private ObservableCollection<Way> _Ways = new ObservableCollection<Way>();
        private ObservableCollection<Station> _Stations = new ObservableCollection<Station>();
        private ObservableCollection<Transport> _Transports = new ObservableCollection<Transport>();

        private CompositeCollection _EntitiesOnMap = new CompositeCollection();

        private DateTime _WorldTime;

        #endregion

        #region Public properties

        public CompositeCollection EntitiesOnMap
        {
            get { return _EntitiesOnMap; }
            set
            {
                _EntitiesOnMap = value;
                OnPropertyChanged(nameof(EntitiesOnMap));
            }
        }

        public ObservableCollection<Way> Ways
        {
            get { return _Ways; }
            set
            {
                _Ways = value;
                OnPropertyChanged(nameof(Ways));
            }
        }

        public ObservableCollection<Station> Stations
        {
            get { return _Stations; }
            set
            {
                _Stations = value;
                OnPropertyChanged(nameof(Stations));
            }
        }

        public ObservableCollection<Transport> Transports
        {
            get { return _Transports; }
            set
            {
                _Transports = value;
                OnPropertyChanged(nameof(Transports));
            }
        }

        public DateTime WorldTime
        {
            get { return _WorldTime; }
            set
            {
                _WorldTime = value;
                OnPropertyChanged(nameof(WorldTime));
            }
        }

        #endregion

        #region Constructor

        public World(int id, string name, int level, int width, int height)
            : base(id, name, level, 0, 0, width, height)
        {
            // A World has no position.

            EntitiesOnMap.Add(new CollectionContainer() { Collection = Ways });
            EntitiesOnMap.Add(new CollectionContainer() { Collection = Stations });
            EntitiesOnMap.Add(new CollectionContainer() { Collection = Transports });

            WorldTime = new DateTime(1800, 1, 1, 0, 0, 0);
        }

        #endregion

        public void AddStation(string name, int level, double posX, double posY)
        {
            Station station = new Station(Stations.Count, name, level, posX, posY);

            Stations.Add(station);

            // Add Route if Station selected. 
            if (Transports.Count > 0) Transports.ElementAt(0).Route.Add(station);
        }

        public void AddTransport(string name, int level, double posX, double posY, double width,
            double height, double vel)
        {
            Transport transport = new Transport(Transports.Count, name, level, posX, posY, width, height, vel);

            Transports.Add(transport);
        }

        public void AddWay(string name, int level, Station start, Station end)
        {
            Way way = new Way(Ways.Count, name, level, start, end);

            Ways.Add(way);
        }

        public Station StationWithID(int id)
        {
            foreach (Station station in Stations)
            {
                if (station.ID == id)
                {
                    return station;
                }
            }
            return null;
        }

        public void UpdateWorld(TimeSpan worldElapsedTime)
        {
            WorldTime += worldElapsedTime;

            foreach (Transport transport in Transports)
            {
                transport.UpdateTransport(worldElapsedTime);
            }
        }
    }
}
