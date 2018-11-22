using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Station : INotifyPropertyChanged
    {
        #region Private attributes

        private int _PosX;
        private int _PosY;
        private int _Radius;

        #endregion

        #region Public properties

        public int PosX
        {
            get { return _PosX; }
            set
            {
                _PosX = value;
                OnPropertyChanged(nameof(PosX));
            }
        }

        public int PosY
        {
            get { return _PosY; }
            set { _PosY = value;
                OnPropertyChanged(nameof(PosY));
            }
        }

        public int Radius
        {
            get { return _Radius; }
            set { _Radius = value;
                OnPropertyChanged(nameof(Radius));
            }
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
