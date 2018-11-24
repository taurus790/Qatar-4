using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Train : INotifyPropertyChanged
    {
        #region Private attributes

        private int _PosX;
        private int _PosY;

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
            set
            {
                _PosY = value;
                OnPropertyChanged(nameof(PosY));
            }
        }

        private int _VelX;
        public int VelX
        {
            get { return _VelX; }
            set
            {
                _VelX = value;
                OnPropertyChanged(nameof(VelX));
            }
        }

        private int _VelY;
        public int VelY
        {
            get { return _VelY; }
            set
            {
                _VelY = value;
                OnPropertyChanged(nameof(VelY));
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
