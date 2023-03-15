using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleNaval.Entity
{
    internal class Submarine : Ship
    {
        public Submarine()
        {
            this._life = 2;
            this._positions = new int[2, 2];
        }
    }
}
