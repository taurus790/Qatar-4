using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ViewModels
{
    public class GameSession
    {
        private Player _CurrentPlayer;
        public Player CurrentPlayer
        {
            get { return _CurrentPlayer; }
            set { _CurrentPlayer = value; }
        }

        private Station _CurrentStation;
        public Station CurrentStation
        {
            get { return _CurrentStation; }
            set { _CurrentStation = value; }
        }

        private Train _CurrentTrain;

        public Train CurrentTrain
        {
            get { return _CurrentTrain; }
            set { _CurrentTrain = value; }
        }
        
        public GameSession()
        {
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Taurus790";
            CurrentPlayer.ImageSrc = "/Engine;component/Images/Player/pic1.png";

            CurrentStation = new Station();
            CurrentStation.PosX = 15;
            CurrentStation.PosY = 15;
            CurrentStation.Level = 15;

            CurrentTrain = new Train();
            CurrentTrain.PosX = 35;
            CurrentTrain.PosY = 15;
        }
    }
}
