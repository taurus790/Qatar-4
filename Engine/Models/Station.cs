using Engine.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Station : BaseCsGameEntity
    {
        #region Private attributes 

        #endregion

        #region Public properties

        #endregion

        #region Constructor

        public Station (int id, string name, double posX, double posY, int level) 
            : base (id, name, posX, posY, level)
        {

        }

        #endregion
    }
}
