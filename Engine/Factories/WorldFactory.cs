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

            newWorld.AddStation(1, "28 May", 20, 10, 20, 10, 10);
            newWorld.AddStation(2, "Gənclik", 10, 100, 100, 10, 10);
            newWorld.AddStation(3, "Nərimanov", 10, 150, 150, 10, 10);

            newWorld.AddTransport(1, "A", 1, 10, 10, 10, 10, 60, 60);

            return newWorld;
        }

        internal static Player CreatePlayer()
        {
            Player newPlayer = new Player(1000000, "/Engine;component/Images/Player/pic1.jpg", 1, "Taurus790", 0);

            return newPlayer;
        }
    }
}
