using BottleSorterWPF.Assets;
using BottleSorterWPF.Enum;
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
        }

        private void SingleBottle_Click(object sender, RoutedEventArgs e)
        {
            Thread produceSingle = new Thread(mana.ProduceSingleBottle);
            Thread sorter = new Thread(mana.SortBottle);
            Thread sConsumer = new Thread(mana.ConsumeSodaBox);
            Thread bConsumer = new Thread(mana.ConsumeBeerBox);

            BottleImage.Opacity = 1;

            produceSingle.Start();
            sorter.Start();
            sConsumer.Start();
            bConsumer.Start();

            MoveToCenter();

            //mana.bottleHandlerEvent += Mana_bottleHandlerEvent;
        }

        //private void Mana_bottleHandlerEvent(object? sender, BottleEventArgs e)
        //{
        //    Dispatcher.Invoke(() => { SodaCounter.Text = e.Bottle.Type.ToString(); });
        //}

        private void MultipleBottles_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SodaCounter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BeerCounter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void MoveToCenter()
        {
            Vector offset = VisualTreeHelper.GetOffset(BottleImage);
            var top = offset.Y;
            var left = offset.X;

            TranslateTransform trans = new TranslateTransform();
            BottleImage.RenderTransform = trans;

            DoubleAnimation anim1 = new DoubleAnimation(0, 245 - top, TimeSpan.FromSeconds(2));
            DoubleAnimation anim2 = new DoubleAnimation(0, 400 - left, TimeSpan.FromSeconds(2));

            anim1.Completed += new EventHandler(Anim1_Completed!);

            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);
        }

        public void Anim1_Completed(object sender, EventArgs e)
        {
            //Bottle bottleType;

            //// Perform check on bottle type, choose animation thereafter
            //bottleType = mana.GetCurrentBottle();

            Random random = new Random();

            if (random.Next(1, 3) == 1)
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

            SetSodaCount();
        }

        public void SetSodaCount()
        {
            int sodaQueueCount = mana.CountSodaQueue();

            SodaCounter.Text = sodaQueueCount.ToString();
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

            SetBeerCount();
        }

        public void SetBeerCount()
        {
            int beerQueueCount = mana.CountBeerQueue();

            BeerCounter.Text = beerQueueCount.ToString();
        }
    }
}
