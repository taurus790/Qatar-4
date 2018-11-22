using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Player : INotifyPropertyChanged
    {
        #region Private attributes

        private string _Name;
        private int _Money;
        private string _ImageSrc;

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

        public int Money
        {
            get { return _Money; }
            set
            {
                _Money = value;
                OnPropertyChanged(nameof(Money));
            }
        }

        public string ImageSrc
        {
            get { return _ImageSrc; }
            set
            {
                _ImageSrc = value;
                OnPropertyChanged(nameof(ImageSrc));
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
