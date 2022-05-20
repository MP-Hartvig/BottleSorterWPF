using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace BottleSorterWPF.Animation
{
    public static class SodaAnimation
    {
        public static void SlideFromLeftToTopRight(this Page page, Image target, float seconds)
        {
            Storyboard sb = new Storyboard();

            sb.AddFadeIn(seconds);

            sb.AddSlideFromLeftToCenterToTopRight(target, seconds);

            //sb.AddFadeOut(seconds);

            sb.Begin(page);
        }        
    }
}
