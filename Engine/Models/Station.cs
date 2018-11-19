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
        private int _PosX;
        public int PosX
        {
            get { return _PosX; }
            set
            {
                _PosX = value;
                OnPropertyChanged(nameof(PosX));
            }
        }

        private int _PosY;
        public int PosY
        {
            get { return _PosY; }
            set { _PosY = value;
                OnPropertyChanged(nameof(PosY));
            }
        }

        private int _Radius;

        public int Radius
        {
            get { return _Radius; }
            set { _Radius = value;
                OnPropertyChanged(nameof(Radius));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
