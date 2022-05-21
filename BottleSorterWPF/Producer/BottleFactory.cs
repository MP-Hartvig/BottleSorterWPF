using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BottleSorterWPF.Producer
{
    // This class generates bottles to a queue
    class BottleFactory
    {
        Queue<Bottle> Bottles;

        public BottleFactory(Queue<Bottle> bottles)
        {
            Bottles = bottles;
        }

        public Bottle ProduceSingleBottle()
        {
            if (Monitor.TryEnter(Bottles))
            {
                try
                {
                    Bottles.Enqueue(new Bottle());
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
            return Bottles.Peek();
        }

        public Bottle[] ProduceMultipleBottles()
        {
            Bottle[] bottles = new Bottle[10];

            if (Monitor.TryEnter(Bottles))
            {
                for (int i = 0; i < bottles.Length; i++)
                {
                    try
                    {
                        Bottles.Enqueue(new Bottle());
                        bottles[i] = Bottles.Peek();
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
            }
            return bottles;
        }
    }
}
