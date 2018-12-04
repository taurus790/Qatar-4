using Engine.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Station : BaseCsGameEntity
    {
        #region Private attributes 

        private double _centerPosX;
        private double _centerPosY;

        #endregion

        #region Public properties

        public double CenterPosX
        {
            get { return _centerPosX; }
            set
            {
                _centerPosX = value;
                PosX = CenterPosX - Width / 2;
                OnPropertyChanged(nameof(CenterPosX));
            }
        }

        public double CenterPosY
        {
            get { return _centerPosY; }
            set
            {
                _centerPosY = value;
                PosY = CenterPosY - Height / 2;
                OnPropertyChanged(nameof(CenterPosY));
            }
        }
        
        public new double Width
        {
            get { return Math.Sqrt(Level) * 10; }
        }

        public new double Height
        {
            get { return Math.Sqrt(Level) * 10; }
        }

        #endregion

        #region Constructor

        public Station(int id, string name, int level, double posX, double posY)
            : base(id, name, level, posX, posY, 0, 0)
        {
            // Width & Height of Stations is determined by Level
            // PosX & PosY by CenterPosX & CenterPosY

            CenterPosX = posX;
            CenterPosY = posY;
        }

        #endregion
    }
}
