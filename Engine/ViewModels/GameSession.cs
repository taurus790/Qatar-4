﻿using Engine.Models;
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
        private bool _isPaused=false;

        private Player _currentPlayer;
        private Station _currentStation;
        private Transport _currentTrain;

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

        public bool IsPaused
        {
            get { return _isPaused; }
            set { _isPaused = value;
                OnPropertyChanged(nameof(IsPaused));
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


        #endregion

        #region Constructor

        public GameSession()
        {
            CurrentPlayer = WorldFactory.CreatePlayer();
            CurrentWorld = WorldFactory.CreateWorld();

            // Every real second is equal to WorldHoursperSecond Hours in the game.
            WorldHoursPerSecond = 1;

            //HACK delete
            AddingNewStation = true;

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        #endregion

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (!IsPaused)
            {
                CurrentWorld.UpdateWorld(WorldElapsedTime);
            }
        }

        #region Recievers from MainWindow.xaml.cs

        public void PausePlayClicked()
        {
            IsPaused = !IsPaused;
        }

        public void MapClicked(double mouseX, double mouseY)
        {
            if (AddingNewStation)
            {
                CurrentWorld.AddStation("5", 1, mouseX, mouseY);
            }
        }

        public void StationClicked(Station clickedStation)
        {
            if (CurrentStation == null)
            {
                CurrentStation = clickedStation;
            }
            else
            {
                CurrentWorld.AddWay("k", 1, CurrentStation, clickedStation);
                CurrentStation = null;
            }
        }

        #endregion
    }
}
