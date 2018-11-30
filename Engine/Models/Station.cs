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

        private double _CenterPosX;
        private double _CenterPosY;

        #endregion

        #region Public properties

        public double CenterPosX
        {
            get { return _CenterPosX; }
            set
            {
                _CenterPosX = value;
                PosX = CenterPosX - Width / 2;
                OnPropertyChanged(nameof(CenterPosX));
            }
        }

        public double CenterPosY
        {
            get { return _CenterPosY; }
            set
            {
                _CenterPosY = value;
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
            CenterPosX = posX;
            CenterPosY = posY;
        }

        #endregion
    }
}
