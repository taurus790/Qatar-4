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

        private int _Width;
        private int _Height;

        #endregion

        #region Public properties

        public new int Width
        {
            get { return Level; }
            set
            {
                _Width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public new int Height
        {
            get { return Level; }
            set
            {
                _Height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        #endregion

        #region Constructor

        public Station (int id, string name, int level, double posX, double posY, int width, int height)
            : base(id, name, level, posX, posY, width, height)
        {

        }

        #endregion
    }
}
