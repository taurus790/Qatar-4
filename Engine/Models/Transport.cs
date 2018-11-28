﻿using Engine.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Transport : BaseCsGameEntity 
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

        public Transport (double velX, double velY,
            int id, string name, int level, double posX, double posY, int width, int height)
            : base(id, name, level, posX, posY, width, height)
        {
            VelX = velX;
            VelY = velY;
        }

        #endregion

    }
}