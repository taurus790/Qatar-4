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
        private int _timeScale;
        private TimeSpan _worldElapsedTime;
        private bool _isPaused = false;

        private Player _currentPlayer;
        private Station _currentStation;
        private Transport _currentTrain;

        private bool _addingNewStation = false;
        private bool _addingNewWay = false;

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

        public int TimeScale
        {
            get { return _timeScale; }
            set
            {
                _timeScale = value;
                // Converts real elapsed time to elapsed time in the game (division by 60 is due 60fps).
                WorldElapsedTime = TimeSpan.FromSeconds(TimeScale * 3600 / 60);
                OnPropertyChanged(nameof(TimeScale));
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
            set
            {
                _isPaused = value;
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

        public bool AddingNewWay
        {
            get { return _addingNewWay; }
            set
            {
                _addingNewWay = value;
                OnPropertyChanged(nameof(AddingNewWay));
            }
        }


        #endregion

        #region Constructor

        public GameSession()
        {

            //HACK delete. Create a Player.
            CurrentPlayer = WorldFactory.CreatePlayer();

            //HACK delete. Create a World.
            CurrentWorld = WorldFactory.CreateWorld();

            //HACK delete. Every real second is equal to WorldHoursperSecond Hours in the game.
            TimeScale = 1;

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        #endregion

        #region Renderer

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (CurrentWorld != null && !IsPaused)
            {
                CurrentWorld.UpdateWorld(WorldElapsedTime);
            }
        }

        #endregion

        #region Recievers from MainWindow.xaml.cs

        public void PausePlayClicked()
        {
            IsPaused = !IsPaused;
        }
        
        #endregion

        #region Helper methods

        public void ClearSelecteds()
        {
            CurrentStation = null;
            CurrentTrain = null;
        }

        public bool AreConnected(Station st1, Station st2)
        {
            foreach (Way way in CurrentWorld.Ways)
            {
                if ((way.StartStation == st1 && way.EndStation == st2) || (way.StartStation == st2 && way.EndStation == st1))
                {
                    return true;
                }
            }
            return false;
        }

        #endregion
    }
}
