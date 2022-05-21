using BottleSorterWPF.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace BottleSorterWPF
{
    public class Bottle
    {
        #region Bottle properties
        private int id;
        private BottleType type;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public BottleType Type
        {
            get => type;
            set => type = value;
        }
        #endregion

        Random random = new Random();

        public Bottle(int bottleId)
        {
            id = bottleId;
            type = (BottleType)random.Next(1, 3);
            Debug.WriteLine($"{Type} created");
        }
    }
}
