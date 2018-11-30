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

        private double _Width;
        private double _Height;

        #endregion

        #region Public properties

        public new double Width
        {
            get { return Level*10; }
            set
            {
                _Width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public new double Height
        {
            get { return Level*10; }
            set
            {
                _Height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        #endregion

        #region Constructor

        public Station (int id, string name, int level, double posX, double posY, double width, double height)
            : base(id, name, level, posX, posY, width, height)
        {

        }

        #endregion
    }
}
