using Engine.Models.Bases;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World : BaseCsGameEntity
    {
        #region Private attributes

        private List<Station> _Stations = new List<Station>();
        private List<Transport> _Transports = new List<Transport>();
        private ObservableCollection<BaseCsGameEntity> _EntitiesOnMap = new ObservableCollection<BaseCsGameEntity>();
        private DateTime _WorldTime;

        #endregion

        #region Public properties

        public List<Station> Stations
        {
            get { return _Stations; }
            set
            {
                _Stations = value;
                OnPropertyChanged(nameof(Stations));
            }
        }

        public List<Transport> Transports
        {
            get { return _Transports; }
            set
            {
                _Transports = value;
                OnPropertyChanged(nameof(Transports));
            }
        }

        public ObservableCollection<BaseCsGameEntity> EntitiesOnMap
        {
            get { return _EntitiesOnMap; }
            set
            {
                _EntitiesOnMap = value;
                OnPropertyChanged(nameof(EntitiesOnMap));
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

            WorldTime = new DateTime(1800, 1, 1, 0, 0, 0);
        }

        #endregion

        internal void AddStation(int id, string name, int level, int posX, int posY, int width, int height)
        {
            Station station = new Station(id, name, level, posX, posY, width, height);

            Stations.Add(station);
            EntitiesOnMap.Add(station);
        }

        internal void AddTransport(int id, string name, int level, int posX, int posY, int width, int height, int velX, int velY)
        {
            Transport transport = new Transport(velX, velY, id, name, level, posX, posY, width, height);

            Transports.Add(transport);
            EntitiesOnMap.Add(transport);
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

            foreach (BaseCsGameEntity gameEntity in EntitiesOnMap)
            {
                if (gameEntity is Transport)
                {
                    // 60 is slowdown
                    gameEntity.PosX += worldElapsedTime.TotalSeconds / 60;
                    gameEntity.PosY += worldElapsedTime.TotalSeconds / 60;
                }
            }
        }
    }
}
