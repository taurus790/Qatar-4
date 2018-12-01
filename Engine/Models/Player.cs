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

        private int _money;
        private string _imageSource;

        #endregion

        #region Public properties 

        public int Money
        {
            get { return _money; }
            set
            {
                _money = value;
                OnPropertyChanged(nameof(Money));
            }
        }

        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        #endregion

        #region Constructor

        public Player(string name, int level,
            int money, string imageSource)
            : base(0, name, level, 0, 0, 0, 0)
        {
            // A player has no position, no width & height.

            Money = money;
            ImageSource = imageSource;
        }

        #endregion
    }
}
