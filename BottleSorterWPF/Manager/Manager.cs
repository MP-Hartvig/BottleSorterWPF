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
        public void InitializeThreads()
        {
            Queue<Bottle> bpQueue = new Queue<Bottle>();
            Queue<Bottle> bcQueue = new Queue<Bottle>();
            Queue<Bottle> scQueue = new Queue<Bottle>();

            BottleFactory bp = new BottleFactory(bpQueue);
            Sorter split = new Sorter(bpQueue, bcQueue, scQueue);
            BeerConsumer bc = new BeerConsumer(bcQueue);
            SodaConsumer sc = new SodaConsumer(scQueue);

            Thread produceSingle = new Thread(bp.ProduceSingleBottle);
            Thread produceMultiple = new Thread(bp.ProduceMultipleBottles);
            Thread splitter = new Thread(split.SplitBottles);
            Thread beerConsumer = new Thread(bc.ConsumeBeer);
            Thread sodaConsumer = new Thread(sc.ConsumeSoda);

            try
            {
                produceSingle.Start();
                produceMultiple.Start();
                splitter.Start();
                sodaConsumer.Start();
                beerConsumer.Start();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            //produceSingle.Join();
            //produceMultiple.Join();
            //splitter.Join();
            //sodaConsumer.Join();
            //beerConsumer.Join();
        }

        //private int id = 0;

        //public void Test()
        //{
        //    Bottle bottle = new Bottle(id);

        //}
    }
}
