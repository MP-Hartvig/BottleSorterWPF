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
        Queue<Bottle> Sodas;

        public SodaConsumer(Queue<Bottle> sodas)
        {
            Sodas = sodas;
        }

        int id = 1;

        public void ConsumeSoda()
        {
            while (Sodas.Count <= 10)
            {
                if (Sodas.Count == 10)
                {
                    while (Sodas.Count != 0)
                    {
                        if (Monitor.TryEnter(Sodas))
                        {
                            try
                            {
                                Bottle bottle = Sodas.Dequeue();
                                Debug.WriteLine($"{bottle.Type} {id} has been consumed");
                                id++;
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
                        Thread.Sleep(100 / 15);
                    }
                }
            }
        }
    }
}
