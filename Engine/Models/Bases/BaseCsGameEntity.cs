using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models.Bases
{
    public class BaseCsGameEntity : BaseCsINotify
    {

        #region Private attributes

        private int _ID;
        private string _Name;
        private double _PosX;
        private double _PosY;
        private int _Level;

        #endregion

        #region Public properties 

        public int ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public double PosX
        {
            get { return _PosX; }
            set
            {
                _PosX = value;
                OnPropertyChanged(nameof(PosX));
            }
        }

        public double PosY
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

        #region Constructor

        public BaseCsGameEntity(int id, string name, double posX, double posY, int level)
        {
            ID = id;
            Name = name;
            PosX = posX;
            PosY = posY;
            Level = level;
        }

        #endregion
    }
}
