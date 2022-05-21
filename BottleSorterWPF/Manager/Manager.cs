using BottleSorterWPF.Consumer;
using BottleSorterWPF.Producer;
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
        static Queue<Bottle> BottleFactoryQueue = new Queue<Bottle>();
        static Queue<Bottle> BeerConsumerQueue = new Queue<Bottle>();
        static Queue<Bottle> SodaConsumerQueue = new Queue<Bottle>();

        BottleFactory bf = new BottleFactory(BottleFactoryQueue);
        Sorter sort = new Sorter(BottleFactoryQueue, BeerConsumerQueue, SodaConsumerQueue);
        BeerConsumer bc = new BeerConsumer(BeerConsumerQueue);
        SodaConsumer sc = new SodaConsumer(SodaConsumerQueue);

        public int CountSodaQueue()
        {
            return SodaConsumerQueue.Count;
        }

        public int CountBeerQueue()
        {
            return BeerConsumerQueue.Count;
        }

        public void ProduceSingleBottle()
        {
            Bottle bottle = bf.ProduceSingleBottle();
        }

        public void ProduceMultipleBottles()
        {
            Bottle[] bottles = bf.ProduceMultipleBottles();
        }

        public void SortBottle()
        {            
            sort.SortBottles();
        }

        public void ConsumeBeerBox()
        {
            bc.ConsumeBeer();
        }

        public void ConsumeSodaBox()
        {
            sc.ConsumeSoda();
        }

        //public event EventHandler<BottleEventArgs> bottleHandlerEvent;
        //public event EventHandler<BottlesEventArgs> bottlesHandlerEvent;

        //public void AddBottle(Bottle bottle)
        //{
        //    bottleHandlerEvent.Invoke(this, new BottleEventArgs(bottle));
        //}

        //public void AddBottles(Bottle[] bottles)
        //{
        //    bottlesHandlerEvent.Invoke(this, new BottlesEventArgs(bottles));
        //}

        //public Bottle GetCurrentBottle()
        //{
        //    Bottle bottleInfo;

        //    if (Monitor.TryEnter(BottleFactoryQueue))
        //    {
        //        if (BottleFactoryQueue.Count == 0)
        //        {
        //            Monitor.Wait(BottleFactoryQueue);
        //        }

        //        try
        //        {                    
        //            return bottleInfo = BottleFactoryQueue.Peek();
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex);
        //        }
        //        finally
        //        {
        //            Monitor.PulseAll(BottleFactoryQueue);
        //            Monitor.Exit(BottleFactoryQueue);
        //        }
        //    }
        //    return bottleInfo;
        //}

        //private int id = 0;

        //public void Test()
        //{
        //    Bottle bottle = new Bottle(id);

        //}
    }
}
