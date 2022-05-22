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
        public BottleFactory BottleF { get; private set; }

        static Queue<Bottle> BottleFactoryQueue = new Queue<Bottle>();
        static Queue<Bottle> BeerConsumerQueue = new Queue<Bottle>();
        static Queue<Bottle> SodaConsumerQueue = new Queue<Bottle>();

        Sorter sort = new Sorter(BottleFactoryQueue, BeerConsumerQueue, SodaConsumerQueue);
        BeerConsumer bc = new BeerConsumer(BeerConsumerQueue);
        SodaConsumer sc = new SodaConsumer(SodaConsumerQueue);

        public Manager()
        {
            BottleF = new BottleFactory(BottleFactoryQueue);
        }

        public int CountBeerQueue()
        {
            return BeerConsumerQueue.Count;
        }

        public void ProduceSingleBottle()
        {
            BottleF.ProduceSingleBottle();
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
    }
}
