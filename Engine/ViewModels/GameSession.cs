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
using System.Windows.Media;

namespace Engine.ViewModels
{
    public class GameSession : BaseCsINotify
    {
        #region Private attributes

        private World _currentWorld;
        private int _worldHoursPerSecond;
        private TimeSpan _worldElapsedTime;

        private Player _currentPlayer;
        private Station _currentStation;
        private Transport _currentTrain;

        //TODO May be there is no need for _selectedStation, and _currentStation can be used instead 
        private Station _selectedStation;

        private bool _addingNewStation;

        #endregion

        #region Public properties 

        public World CurrentWorld
        {
            get { return _currentWorld; }
            set
            {
                _currentWorld = value;
                OnPropertyChanged(nameof(CurrentWorld));
            }
        }

        public int WorldHoursPerSecond
        {
            get { return _worldHoursPerSecond; }
            set
            {
                _worldHoursPerSecond = value;
                // Converts real elapsed time to elapsed time in the game (division by 60 is due 60fps).
                WorldElapsedTime = TimeSpan.FromSeconds(WorldHoursPerSecond * 3600 / 60);
                OnPropertyChanged(nameof(WorldHoursPerSecond));
            }
        }

        public TimeSpan WorldElapsedTime
        {
            get { return _worldElapsedTime; }
            set
            {
                _worldElapsedTime = value;
                OnPropertyChanged(nameof(WorldElapsedTime));
            }
        }

        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
                _currentPlayer = value;
                OnPropertyChanged(nameof(CurrentPlayer));
            }
        }

        public Station CurrentStation
        {
            get { return _currentStation; }
            set
            {
                _currentStation = value;
                OnPropertyChanged(nameof(CurrentStation));
            }
        }

        public Transport CurrentTrain
        {
            get { return _currentTrain; }
            set
            {
                _currentTrain = value;
                OnPropertyChanged(nameof(CurrentTrain));
            }
        }

        public bool AddingNewStation
        {
            get { return _addingNewStation; }
            set
            {
                _addingNewStation = value;
                OnPropertyChanged(nameof(AddingNewStation));
            }
        }

        public Station SelectedStation
        {
            get { return _selectedStation; }
            set
            {
                _selectedStation = value;
                OnPropertyChanged(nameof(SelectedStation));
            }
        }


        #endregion

        #region Constructor

        public GameSession()
        {
            CurrentPlayer = WorldFactory.CreatePlayer();
            CurrentWorld = WorldFactory.CreateWorld();
            CurrentStation = CurrentWorld.StationWithID(0);

            // Every real second is equal to WorldHoursperSecond Hours in the game.
            WorldHoursPerSecond = 1;

            AddingNewStation = true;

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        #endregion

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            CurrentWorld.UpdateWorld(WorldElapsedTime);
        }

        #region Recievers from MainWindow.xaml.cs

        public void MapClicked(double mouseX, double mouseY)
        {
            if (AddingNewStation)
            {
                CurrentWorld.AddStation("5", 1, mouseX, mouseY);
            }
        }

        public void StationClicked(Station clickedStation)
        {
            if (SelectedStation == null)
            {
                SelectedStation = clickedStation;
            }
            else
            {
                CurrentWorld.AddWay("k", 1, SelectedStation, clickedStation);
                SelectedStation = null;
            }
        }

        #endregion
    }
}
