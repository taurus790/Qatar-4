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
            World newWorld = new World(1, "First World", 0, 0, 0);

            newWorld.AddStation(1, "28 May", 10, 10, 20);
            newWorld.AddStation(2, "Gənclik", 100, 100, 10);
            newWorld.AddStation(3, "Nərimanov", 150, 150, 10);

            return newWorld;
        }

        internal static Player CreatePlayer()
        {
            Player newPlayer = new Player(1000000, "/Engine;component/Images/Player/pic1.jpg",1,"Taurus790",0,0,0);

            return newPlayer;
        }
    }
}
