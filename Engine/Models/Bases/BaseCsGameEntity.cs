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

        private int _id;
        private string _name;
        private int _level;

        private double _posX;
        private double _posY;

        private double _width;
        private double _height;

        #endregion

        #region Public properties 

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public int Level
        {
            get { return _level; }
            set
            {
                _level = value;
                OnPropertyChanged(nameof(Level));
            }
        }

        public double PosX
        {
            get { return _posX; }
            set
            {
                _posX = value;
                OnPropertyChanged(nameof(PosX));
            }
        }

        public double PosY
        {
            get { return _posY; }
            set
            {
                _posY = value;
                OnPropertyChanged(nameof(PosY));
            }
        }

        public double Width
        {
            get { return _width; }
            set
            {
                _width = value;
                OnPropertyChanged(nameof(Width));
            }
        }

        public double Height
        {
            get { return _height; }
            set
            {
                _height = value;
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
            Width = width;
            Height = height;
            PosX = posX;
            PosY = posY;
        }

        #endregion
    }
}
