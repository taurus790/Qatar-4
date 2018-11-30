using Engine.Models.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Way : BaseCsGameEntity
    {
        #region Private attributes 
        
        #endregion

        #region Public properties
        
        #endregion

        #region Constructor

        public Way (int id, string name, int level, double posX, double posY, double width, double height)
            : base(id, name, level, posX, posY, width, height)
        {

        }

        #endregion
    }
}
