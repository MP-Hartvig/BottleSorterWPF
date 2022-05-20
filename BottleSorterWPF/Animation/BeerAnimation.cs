using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Threading;

namespace BottleSorterWPF.Animation
{
    public static class BeerAnimation
    {
        public static void SlideFromLeftToBottomRight(this Page page, float seconds)
        {
            Storyboard sb = new Storyboard();

            sb.AddSlideFromLeftToCenterToBottomRight(seconds);

            sb.AddFadeIn(seconds);

            sb.Begin(page);

            page.Visibility = Visibility.Visible;
        }
    }
}
