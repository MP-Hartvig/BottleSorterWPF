using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottleSorterWPF.Producer
{
    public class BottlesEventArgs : EventArgs
    {
        public Bottle[] Bottles { get; set; }

        public BottlesEventArgs(Bottle[] bottles)
        {
            Bottles = bottles;
        }
    }
}
