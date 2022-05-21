using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BottleSorterWPF.Producer
{
    class BottleFactory
    {
        Queue<Bottle> bottles;

        public BottleFactory(Queue<Bottle> bottleQueue)
        {
            bottles = bottleQueue;
        }

        int bottleId = 1;

        public void ProduceSingleBottle()
        {
            if (Monitor.TryEnter(bottles))
            {
                try
                {
                    bottles.Enqueue(new Bottle(bottleId));
                    bottleId++;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
                finally
                {
                    Monitor.PulseAll(bottles);
                    Monitor.Exit(bottles);
                }
            }
        }

        public void ProduceMultipleBottles()
        {
            int maxAmount = 0;

            if (Monitor.TryEnter(bottles))
            {
                while (maxAmount < 10)
                {
                    try
                    {
                        bottles.Enqueue(new Bottle(bottleId));
                        bottleId++;
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex);
                    }
                    finally
                    {
                        Monitor.PulseAll(bottles);
                        Monitor.Exit(bottles);
                    }
                    Thread.Sleep(100 / 15);
                }
            }
        }
    }
}
