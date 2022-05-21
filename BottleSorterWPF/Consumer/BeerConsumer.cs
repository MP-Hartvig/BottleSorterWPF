using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BottleSorterWPF.Consumer
{
    // This class dequeues the beer queue
    class BeerConsumer
    {
        Queue<Bottle> beers;

        public BeerConsumer(Queue<Bottle> beerQueue)
        {
            beers = beerQueue;
        }

        public void ConsumeBeer()
        {
            if (beers.Count == 9)
            {
                while (beers.Count != 0)
                {
                    Monitor.TryEnter(beers);

                    //if (beers.Count == 0)
                    //{
                    //    Monitor.Wait(beers);
                    //}

                    Bottle bottle = beers.Dequeue();
                    Debug.WriteLine($"{bottle.Type} {bottle.Id} has been consumed");

                    Monitor.Pulse(beers);
                    Monitor.Exit(beers);

                    Thread.Sleep(100 / 15);
                }
            }
        }
    }
}
