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
    /// This class generates bottles to a queue
    /// </summary>
    public class BottleFactory
    {
        public event EventHandler<BottleEventArgs> BottleCreated;

        Queue<Bottle> Bottles;

        public BottleFactory(Queue<Bottle> bottles)
        {
            Bottles = bottles;
        }

        public void BottleCreatedEvent(Bottle bottle)
        {
            BottleCreated?.Invoke(this, new BottleEventArgs(bottle));
        }

        public void ProduceSingleBottle()
        {
            Bottle bottle = null!;

            while (bottle is null)
            {
                if (Monitor.TryEnter(Bottles))
                {
                    bottle = new Bottle();

                    try
                    {
                        Bottles.Enqueue(bottle);                        
                        BottleCreatedEvent(bottle);
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
        }
    }
}
