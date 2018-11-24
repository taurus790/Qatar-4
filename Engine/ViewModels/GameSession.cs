using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Factories;
using System.Collections.ObjectModel;

namespace Engine.ViewModels
{
    public class GameSession
    {
        #region Public properties

        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }
        public Station CurrentStation { get; set; }
        public Train CurrentTrain { get; set; }
        public ObservableCollection<Station> Colc { get; set; }

        #endregion

        #region Constructor

        public GameSession()
        {
            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentStation = CurrentWorld.StationWithID(1);


            Colc = new ObservableCollection<Station>(
                                CurrentWorld.Stations.Select(c => new Station(c.ID, c.Name, c.PosX, c.PosY, c.Level)));

            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Taurus790";
            CurrentPlayer.ImageSrc = "/Engine;component/Images/Player/pic1.jpg";
            CurrentPlayer.Money = 1000000;

            CurrentTrain = new Train();
            CurrentTrain.PosX = 35;
            CurrentTrain.PosY = 15;
        }

        #endregion

    }
}
