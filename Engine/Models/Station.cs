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

        private string _Name;
        private int _PosX;
        private int _PosY;
        private int _Level;

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

        public int Level
        {
            get { return _Level; }
            set
            {
                _Level = value;
                OnPropertyChanged(nameof(Level));
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
