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
    /// <summary>
    /// This class represents a bottle with an enum type property
    /// </summary>
    public class Bottle
    {
        #region Bottle properties
        private BottleType type;

        public BottleType Type
        {
            get => type;
        }
        #endregion

        Random random = new Random();

        public Bottle()
        {
            type = (BottleType)random.Next(1, 3);
            Debug.WriteLine($"{Type} created");
        }
    }
}
