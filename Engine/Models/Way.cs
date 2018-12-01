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

        private Station _startStation;
        private Station _endStation;

        #endregion

        #region Public properties

        public Station StartStation
        {
            get { return _startStation; }
            set
            {
                _startStation = value;
                OnPropertyChanged(nameof(StartStation));
            }
        }

        public Station EndStation
        {
            get { return _endStation; }
            set
            {
                _endStation = value;
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
            // Width of a Way is the horizontal distance between its start and end. 
            // Height of a Way is the vertical distance between its start and end. 


            StartStation = startStation;
            EndStation = endStation;
        }
        #endregion
    }
}
