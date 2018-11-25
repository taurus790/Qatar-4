using Engine.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Player : BaseCsGameEntity
    {
        #region Private attributes

        private int _Money;
        private string _ImageSrc;

        #endregion

        #region Public properties 

        public int Money
        {
            get { return _Money; }
            set
            {
                _Money = value;
                OnPropertyChanged(nameof(Money));
            }
        }

        public string ImageSrc
        {
            get { return _ImageSrc; }
            set
            {
                _ImageSrc = value;
                OnPropertyChanged(nameof(ImageSrc));
            }
        }

        #endregion

        #region Constructor

        public Player(int money, string imageSrc, int id, string name, double posX, double posY, int level) 
            : base (id, name, posX, posY, level)
        {
            Money = money;
            ImageSrc = imageSrc;

            // A player has no position. 
            PosX = 0;
            PosY = 0;
        }

        #endregion
    }
}
