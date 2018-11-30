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

            newWorld.AddStation("28 May", 1, 10, 30);
            newWorld.AddStation("Gənclik", 1, 100, 50);

            newWorld.AddTransport("A", 1, 10, 10, 10, 10, 60, 60);

            newWorld.AddWay("N.Tusi", 1, newWorld.Stations.ElementAt(0), newWorld.Stations.ElementAt(1));

            return newWorld;
        }

        internal static Player CreatePlayer()
        {
            Player newPlayer = new Player(1000000, "/Engine;component/Images/Player/pic1.jpg", 1, "Taurus790", 0);

            return newPlayer;
        }
    }
}
