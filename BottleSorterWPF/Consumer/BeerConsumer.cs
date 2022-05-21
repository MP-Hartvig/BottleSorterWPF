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
        Queue<Bottle> Beers;

        public BeerConsumer(Queue<Bottle> beers)
        {
            Beers = beers;
        }

        int id = 1;

        public void ConsumeBeer()
        {
            while (Beers.Count <= 10)
            {
                if (Beers.Count == 10)
                {
                    while (Beers.Count != 0)
                    {
                        if (Monitor.TryEnter(Beers))
                        {
                            try
                            {
                                Bottle bottle = Beers.Dequeue();
                                Debug.WriteLine($"{bottle.Type} {id} has been consumed");
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine(ex);
                            }
                            finally
                            {
                                Monitor.Pulse(Beers);
                                Monitor.Exit(Beers);
                            }
                        }
                        Thread.Sleep(100 / 15);
                    }
                }
            }
        }
    }
}
