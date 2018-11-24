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

            newWorld.AddStation(1, "28 May", 10, 10, 20);
            newWorld.AddStation(2, "Gənclik", 100, 100, 10);
            newWorld.AddStation(3, "Nərimanov", 150, 150, 10);

            return newWorld;
        }
    }
}
