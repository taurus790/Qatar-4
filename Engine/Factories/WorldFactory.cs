using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World  CreateWorld()
        {
            World newWorld = new World(1, "First World", 0, 800, 500);

            return newWorld;

            /*
            newWorld.AddStation("28 May", 1, 100, 100);
            newWorld.AddStation("Gənclik", 1, 200, 100);

            newWorld.AddTransport("A", 1,
                newWorld.Stations.ElementAt(0).CenterPosX,
                newWorld.Stations.ElementAt(0).CenterPosY,
                10, 10, 60);
            newWorld.Transports.ElementAt(0).Route.Add(newWorld.Stations.ElementAt(0));
            newWorld.Transports.ElementAt(0).Route.Add(newWorld.Stations.ElementAt(1));
            newWorld.Transports.ElementAt(0).Origin = newWorld.Stations.ElementAt(0);
            newWorld.Transports.ElementAt(0).Destination = newWorld.Stations.ElementAt(1);
            newWorld.Transports.ElementAt(0).CalculateVels();

            newWorld.AddWay("N.Tusi", 1, newWorld.Stations.ElementAt(0), newWorld.Stations.ElementAt(1));
            */
        }

        
        internal static Player CreatePlayer()
        {
            Player newPlayer = new Player("Tau", 0, 1000, "/Engine;component/Images/Player/pic1.jpg");

            return newPlayer;
        }
    }
}
