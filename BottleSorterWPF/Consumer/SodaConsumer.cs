using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BottleSorterWPF.Consumer
{
    // This class dequeues the soda queue
    class SodaConsumer
    {
        Queue<Bottle> sodas;

        public SodaConsumer(Queue<Bottle> sodaQueue)
        {
            sodas = sodaQueue;
        }

        public void ConsumeSoda()
        {
            if (sodas.Count == 10)
            {
                while (sodas.Count != 0)
                {
                    Monitor.TryEnter(sodas);

                    //if (sodas.Count == 0)
                    //{
                    //    Monitor.Wait(sodas);
                    //}

                    Bottle bottle = sodas.Dequeue();
                    Debug.WriteLine($"{bottle.Type + " " + bottle.Id} has been consumed");

                    Monitor.Pulse(sodas);
                    Monitor.Exit(sodas);

                    Thread.Sleep(100 / 15);
                }
            }
        }
    }
}
