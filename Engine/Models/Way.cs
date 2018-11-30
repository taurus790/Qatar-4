using Engine.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Way : BaseCsGameEntity
    {
        #region Private attributes 

        private Station _StartStation;
        private Station _EndStation;

        #endregion

        #region Public properties

        public Station StartStation
        {
            get { return _StartStation; }
            set
            {
                _StartStation = value;
                OnPropertyChanged(nameof(StartStation));
            }
        }

        public Station EndStation
        {
            get { return _EndStation; }
            set
            {
                _EndStation = value;
                OnPropertyChanged(nameof(EndStation));
            }
        }

        #endregion

        #region Constructor
        
        public Way(int id, string name, int level,
            Station startStation, Station endStation)
            : base(id, name, level,
                  startStation.CenterPosX,
                  startStation.CenterPosY,
                  endStation.CenterPosX - startStation.CenterPosX,
                  endStation.CenterPosY - startStation.CenterPosY)
        {
            StartStation = startStation;
            EndStation = endStation;
        }
        #endregion
    }
}
