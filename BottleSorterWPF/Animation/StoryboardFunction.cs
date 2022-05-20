using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace BottleSorterWPF.Animation
{
    // This class is an extension to the Storyboard class
    public static class StoryboardFunction
    {
        // Hard coded these properties, could be set through constructor if window size at some point becomes dynamic
        private static double horizontalOffset;
        private static double verticalOffset;
        private static double horizontalEndpoint;
        private static double verticalEndpointTop;
        private static double verticalEndpointBottom;

        public static void AddSlideFromLeftToCenterToTopRight(this Storyboard storyboard, Image target, float seconds)
        {
            // First part of the animation
            Vector offset = VisualTreeHelper.GetOffset(target);
            var top = offset.Y;
            var left = offset.X;

            TranslateTransform trans = new TranslateTransform();
            target.RenderTransform = trans;

            DoubleAnimation anim1 = new DoubleAnimation(0, 245 - top, TimeSpan.FromSeconds(2));
            DoubleAnimation anim2 = new DoubleAnimation(0, 400 - left, TimeSpan.FromSeconds(2));

            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);

            //anim1.Completed += new EventHandler(Anim1_Completed());

            //ThicknessAnimation? animation = new ThicknessAnimation
            //{
            //    Duration = new Duration(TimeSpan.FromSeconds(seconds)),
            //    From = new Thickness(horizontalOffset, verticalOffset, horizontalEndpoint, verticalEndpointTop), // Left - Top - Right - Bottom
            //    To = new Thickness(0)
            //};

            //Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            //storyboard.Children.Add(animation);
        }

        private static void Anim1_Completed(object sender, EventArgs e)
        {
            DoubleAnimation anim1 = new DoubleAnimation(0, 245, TimeSpan.FromSeconds(2));
            DoubleAnimation anim2 = new DoubleAnimation(0, 400, TimeSpan.FromSeconds(2));

            TranslateTransform trans = new TranslateTransform();

            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);
        }

        public static void AddSlideFromLeftToCenterToBottomRight(this Storyboard storyboard, float seconds)
        {
            ThicknessAnimation? animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(horizontalOffset, verticalOffset, horizontalEndpoint, verticalEndpointBottom), // Left - Top - Right - Bottom
                To = new Thickness(0)
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            storyboard.Children.Add(animation);
        }

        public static void AddFadeIn(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1,
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            storyboard.Children.Add(animation);
        }

        public static void AddFadeOut(this Storyboard storyboard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0,
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            storyboard.Children.Add(animation);
        }
    }

}
