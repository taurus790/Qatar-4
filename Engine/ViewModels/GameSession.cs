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

        private World _CurrentWorld;
        private int _WorldHoursPerSecond;
        private TimeSpan _WorldElapsedTime;
        private Player _CurrentPlayer;
        private Station _CurrentStation;
        private Transport _CurrentTrain;

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

        public int WorldHoursperSecond
        {
            get { return _WorldHoursPerSecond; }
            set
            {
                _WorldHoursPerSecond = value;
                WorldElapsedTime = TimeSpan.FromSeconds(WorldHoursperSecond * 60 * 60 / 60);
                OnPropertyChanged(nameof(WorldHoursperSecond));
            }
        }

        public TimeSpan WorldElapsedTime
        {
            get { return _WorldElapsedTime; }
            set
            {
                _WorldElapsedTime = value;
                OnPropertyChanged(nameof(WorldElapsedTime));
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

        public Transport CurrentTrain
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
            CurrentPlayer = WorldFactory.CreatePlayer();
            CurrentWorld = WorldFactory.CreateWorld();
            CurrentStation = CurrentWorld.StationWithID(1);

            // Every real second is equal to WorldHoursperSecond Hours in the game (division by 60 is due 60fps)
            WorldHoursperSecond = 2;

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }

        #endregion

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            CurrentWorld.UpdateWorld(WorldElapsedTime);
        }
    }
}
