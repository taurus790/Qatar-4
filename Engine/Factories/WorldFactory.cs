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
            newWorld.AddStation("Gənclik", 2, 20, 30);
            newWorld.AddStation("Nərimanov", 3, 40, 30);
            newWorld.AddStation("Nərimanov", 4, 60, 30);
            newWorld.AddStation("Nərimanov", 5, 80, 30);

            newWorld.AddTransport("A", 1, 10, 10, 10, 10, 60, 60);

            newWorld.AddWay("N.Tusi", 1, 10, 10, 100, 200);

            return newWorld;
        }

        internal static Player CreatePlayer()
        {
            Player newPlayer = new Player(1000000, "/Engine;component/Images/Player/pic1.jpg", 1, "Taurus790", 0);

            return newPlayer;
        }
    }
}
