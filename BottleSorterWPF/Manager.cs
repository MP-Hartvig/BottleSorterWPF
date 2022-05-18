using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BottleSorterWPF.Assets
{
    public class Manager
    {
        public event EventHandler<BottleEventArgs> bottleHandlerEvent;

        // This triggers by receiving a bottle
        public void BottleAdded(Bottle bottle)
        {
            bottleHandlerEvent?.Invoke(this, new BottleEventArgs(bottle));
        }

        public void GenerateBottle()
        {
            while (true)
            {
                BottleAdded(new Bottle());
                Debug.WriteLine("Bottle was generated");
                Thread.Sleep(3000);
            }
        }
    }
}
