using Engine.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Train : BaseCsGameEntity 
    {
        #region Private attributes

        private double _VelX;
        private double _VelY;

        #endregion

        #region Public properties

        public double VelX
        {
            get { return _VelX; }
            set
            {
                _VelX = value;
                OnPropertyChanged(nameof(VelX));
            }
        }

        public double VelY
        {
            get { return _VelY; }
            set
            {
                _VelY = value;
                OnPropertyChanged(nameof(VelY));
            }
        }

        #endregion

        #region Constructor

        public Train (double velX, double velY, int id, string name, double posX, double posY, int level)
            : base(id, name, posX, posY, level)
        {
            VelX = velX;
            VelY = velY;
        }

        #endregion

    }
}
