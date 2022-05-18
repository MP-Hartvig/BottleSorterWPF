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
        public int Id { get; private set; }
        public BottleType Type { get; private set; }
        #endregion

        #region Animation properties
        /// <summary>
        /// The animation to play when a bottle is produced
        /// </summary>
        public AnimationType BottleStartAnimation { get; private set; } = AnimationType.SlideAndFadeInFromLeft;

        /// <summary>
        /// The animation to play when a bottle is sorted to the soda queue
        /// </summary>
        public AnimationType SodaAnimation { get; private set; } = AnimationType.SlideAndFadeOutTopRight;

        /// <summary>
        /// The animation to play when a bottle is sorted to the beer queue
        /// </summary>
        public AnimationType BeerAnimation { get; private set; } = AnimationType.SlideAndFadeOutBottomRight;

        /// <summary>
        /// The time a slide animation takes to complete
        /// </summary>
        public int SlideSeconds { get; private set; } = 2;
        #endregion

        Random random = new Random();

        public Bottle()
        {
            Type = (BottleType)random.Next(1, 3);
            Debug.WriteLine($"{Type} created");
        }

        public Task BeerAnimation()
        {
            Storyboard sb = new Storyboard();
            var slideAnimation = new ThicknessAnimation { 
                Duration = new Duration(new TimeSpan(this.SlideSeconds)), 
                From = new Thickness(),
                To = new Thickness(),
                
            };
        }

        public Task SodaAnimation()
        {
            Storyboard sb = new Storyboard();
        }
    }
}
