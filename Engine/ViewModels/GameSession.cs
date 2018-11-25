using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Engine.Models.Bases;
using System.Windows.Threading;

namespace Engine.ViewModels
{
    public class GameSession : BaseCsINotify
    {
        #region Private attributes

        private double _UpdateInterval; // The updates/ticks every [_UpdateInterval] milliseconds
        private DispatcherTimer _Updater;


        private World _CurrentWorld;
        private Player _CurrentPlayer;
        private Station _CurrentStation;
        private Train _CurrentTrain;

        #endregion

        #region Public properties 

        public World CurrentWorld
        {
            get { return _CurrentWorld; }
            set
            {
                _CurrentWorld = value;
                OnPropertyChanged(nameof(CurrentWorld));
            }
        }

        public Player CurrentPlayer
        {
            get { return _CurrentPlayer; }
            set
            {
                _CurrentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        public Station CurrentStation
        {
            get { return _CurrentStation; }
            set
            {
                _CurrentStation = value;
                OnPropertyChanged(nameof(CurrentStation));
            }
        }

        public Train CurrentTrain
        {
            get { return _CurrentTrain; }
            set
            {
                _CurrentTrain = value;
                OnPropertyChanged(nameof(CurrentTrain));
            }
        }

        #endregion

        #region Constructor

        public GameSession()
        {
            WorldFactory factory = new WorldFactory();
            CurrentPlayer = factory.CreatePlayer();
            CurrentWorld = factory.CreateWorld();

            CurrentStation = CurrentWorld.StationWithID(1);

            _UpdateInterval = 40; // The updates/ticks every [_UpdateInterval] milliseconds
            _Updater = new DispatcherTimer();
            _Updater.Interval = TimeSpan.FromMilliseconds(_UpdateInterval);
            _Updater.Tick += UpdateWorld;
            _Updater.Start();
        }

        #endregion

        private void UpdateWorld(object sender, EventArgs e)
        {
            CurrentWorld.UpdateWorld(5);
        }
    }
}
