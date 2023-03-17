using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleNaval.Entity
{
    internal abstract class Ship
    {
        public int _life { get; set; }
        public int[,] _positions { get; set; }
        private void TakeLife()
        {
            this._life--;
        }
    }
}
