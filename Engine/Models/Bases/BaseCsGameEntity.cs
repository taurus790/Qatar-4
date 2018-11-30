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

        private double _Width;
        private double _Height;

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

        public int Level
        {
            get { return _Level; }
            set
            {
                _Level = value;
                OnPropertyChanged(nameof(Level));
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

        public double Width
        {
            get { return _Width; }
            set
            {
                _Width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public double Height
        {
            get { return _Height; }
            set
            {
                _Height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        #endregion

        #region Constructor

        public BaseCsGameEntity(int id, string name, int level, double posX, double posY, double width, double height)
        {
            ID = id;
            Name = name;
            Level = level;
            PosX = posX;
            PosY = posY;
            Width = width;
            Height = height;
        }

        #endregion
    }
}
