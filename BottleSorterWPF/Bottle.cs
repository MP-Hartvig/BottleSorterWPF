using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BottleSorterWPF
{
    public enum BottleType
    {
        Soda = 1,
        Beer = 2,
        Can = 3
    }

    public class Bottle
    {
        public BottleType Type { get; private set; }

        Random random = new Random();

        public Bottle()
        {
            Type = (BottleType)random.Next(1, 4);
            Debug.WriteLine($"Bottle created {Type}");
        }
    }
}
