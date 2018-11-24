using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine.Models;

namespace Engine.Factories
{
    internal class WorldFactory
    {
        internal World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddStation(1, "28 May", 15, 15, 20);
            newWorld.AddStation(2, "Gənclik", 30, 30, 10);
            newWorld.AddStation(3, "Nərimanov", 45, 45, 10);

            return newWorld;
        }
    }
}
