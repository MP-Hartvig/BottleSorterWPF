using BottleSorterWPF.Assets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BottleSorterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Manager mana = new Manager();

        public MainWindow()
        {
            InitializeComponent();

            //Thread t = new Thread(mana.GenerateBottle);

            //t.Start();

            //mana.bottleHandlerEvent += Mana_bottleHandlerEvent;
        }

        //private void Mana_bottleHandlerEvent(object? sender, BottleEventArgs e)
        //{
        //    Dispatcher.Invoke(() => { Label1.Content = e.Bottle.Type.ToString(); });            
        //}

        private void SingleBottle_Click(object sender, RoutedEventArgs e)
        {
            BottleImage.Opacity = 1;

            // Needs X and Y coordinates
            MoveToCenter(BottleImage);
        }

        private void MultipleBottles_Click(object sender, RoutedEventArgs e)
        {
            //int bottleCount = 0;

            //while (bottleCount < 10)
            //{
            //    var horizontalAlignment = bottleBelt.TranslatePoint;
            //    var verticalAlignment = bottleBelt.VerticalAlignment;



            //    bottleCount++;
            //    Thread.Sleep(2500);
            //}
        }

        private void SodaCounter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BeerCounter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void MoveToCenter(Image target)
        {
            Vector offset = VisualTreeHelper.GetOffset(target);
            var top = offset.Y;
            var left = offset.X;

            TranslateTransform trans = new TranslateTransform();
            target.RenderTransform = trans;

            DoubleAnimation anim1 = new DoubleAnimation(0, 245 - top, TimeSpan.FromSeconds(2));
            DoubleAnimation anim2 = new DoubleAnimation(0, 400 - left, TimeSpan.FromSeconds(2));

            anim1.Completed += new EventHandler(Anim1_Completed!);

            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);
        }

        public void Anim1_Completed(object sender, EventArgs e)
        {
            Random random = new Random();

            // Perform check on bottle type, choose animation thereafter

            if (random.Next(2) == 0)
            {
                MoveToTopRight(BottleImage);
            }
            else
            {
                MoveToBottomRight(BottleImage);
            }
        }

        public void MoveToTopRight(Image target)
        {
            Vector offset = VisualTreeHelper.GetOffset(target);
            var top = offset.Y;
            var left = offset.X;

            TranslateTransform trans = new TranslateTransform();
            target.RenderTransform = trans;

            DoubleAnimation anim1 = new DoubleAnimation(0, 75 - top, TimeSpan.FromSeconds(2));
            DoubleAnimation anim2 = new DoubleAnimation(315, 540 - left, TimeSpan.FromSeconds(2));

            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);
        }

        public void MoveToBottomRight(Image target)
        {
            Vector offset = VisualTreeHelper.GetOffset(target);
            var top = offset.Y;
            var left = offset.X;

            TranslateTransform trans = new TranslateTransform();
            target.RenderTransform = trans;

            DoubleAnimation anim1 = new DoubleAnimation(0, 370 - top, TimeSpan.FromSeconds(2));
            DoubleAnimation anim2 = new DoubleAnimation(315, 535 - left, TimeSpan.FromSeconds(2));

            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);
        }
    }
}
