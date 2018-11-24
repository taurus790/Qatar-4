using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World : INotifyPropertyChanged
    {
        #region Private attributes

        private List<Station> _Stations = new List<Station>();

        private ObservableCollection<Station> _EntitiesOnMap = new ObservableCollection<Station>();

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

        public ObservableCollection<Station> EntitiesOnMap
        {
            get { return _EntitiesOnMap; }
            set
            {
                _EntitiesOnMap = value;
                OnPropertyChanged(nameof(EntitiesOnMap));
            }
        }

        #endregion

        internal void AddStation(int id, string name, int posX, int posY, int level)
        {
            Station station = new Station(id, name, posX, posY, level);

            Stations.Add(station);
            EntitiesOnMap.Add(station);
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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
