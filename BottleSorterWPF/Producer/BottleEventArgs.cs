using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottleSorterWPF
{
    public class BottleEventArgs : EventArgs
    {
        public Bottle Bottle { get; set; }

        public BottleEventArgs(Bottle bottle)
        {
            Bottle = bottle;
        }
    }
}
