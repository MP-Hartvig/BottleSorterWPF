using BottleSorterWPF.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BottleSorterWPF.Producer
{
    /// <summary>
    /// This class sorts bottles into seperate queues
    /// </summary>
    class Sorter
    {
        Queue<Bottle> Bottles;
        Queue<Bottle> Beers;
        Queue<Bottle> Sodas;

        public Sorter(Queue<Bottle> bottleQueue, Queue<Bottle> beerQueue, Queue<Bottle> sodaQueue)
        {
            Beers = beerQueue;
            Sodas = sodaQueue;
            Bottles = bottleQueue;
        }

        public void SortBottles()
        {
            while (Bottles.Count > 0)
            {
                if (Monitor.TryEnter(Bottles))
                {
                    try
                    {
                        Bottle dequeuedBottle = Bottles.Dequeue();

                        if (dequeuedBottle.Type.Equals(BottleType.Beer))
                        {
                            EnqueueBeer(dequeuedBottle);
                        }
                        else
                        {
                            EnqueueSoda(dequeuedBottle);
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                    finally
                    {
                        Monitor.PulseAll(Bottles);
                        Monitor.Exit(Bottles);
                    }
                }
                Thread.Sleep(100 / 15);
            }
        }

        private void EnqueueBeer(Bottle enqueueBottle)
        {
            if (Monitor.TryEnter(Beers))
            {
                if (Beers.Count > 9)
                {
                    Monitor.Wait(Beers);
                }

                try
                {
                    Beers.Enqueue(enqueueBottle);
                    Debug.WriteLine($"{enqueueBottle.Type} was relocated");
                }
                catch (Exception)
                {
                    Monitor.Pulse(Beers);
                    Monitor.Exit(Beers);
                }
            }
        }

        private void EnqueueSoda(Bottle enqueueBottle)
        {
            if (Monitor.TryEnter(Sodas))
            {
                if (Sodas.Count > 9)
                {
                    Monitor.Wait(Sodas);
                }

                try
                {
                    Sodas.Enqueue(enqueueBottle);
                    Debug.WriteLine($"{enqueueBottle.Type} was relocated");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    Monitor.Pulse(Sodas);
                    Monitor.Exit(Sodas);
                }
            }
        }
    }
}
