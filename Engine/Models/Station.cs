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
        private int _ID;
        private int _PosX;
        private int _PosY;
        private int _Level;

        #endregion

        #region Public properties

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }

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

        #region Construction 

        public Station(int id, string name, int posX, int posY, int level)
        {
            ID = id;
            Name = name;
            PosX = posX;
            PosY = posY;
            Level = level;
        }

        #endregion

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
