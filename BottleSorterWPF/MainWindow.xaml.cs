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

        Thread produceSingle;
        Thread sConsumer;
        Thread bConsumer;
        Thread sorter;

        Bottle currentBottle;

        public MainWindow()
        {
            InitializeComponent();
            
            sorter = new Thread(mana.SortBottle);
            sConsumer = new Thread(mana.ConsumeSodaBox);
            bConsumer = new Thread(mana.ConsumeBeerBox);

            sorter.Start();
            sConsumer.Start();
            bConsumer.Start();

            mana.BottleF.BottleCreated += BottleF_BottleCreated;
        }

        private void BottleF_BottleCreated(object? sender, BottleEventArgs e)
        {
            currentBottle = e.Bottle;
            Dispatcher?.Invoke(() => { BottleImage.Opacity = 1; });
            Dispatcher?.Invoke(() => { MoveToCenter(); });
        }

        private void SingleBottle_Click(object sender, RoutedEventArgs e)
        {
            produceSingle = new Thread(mana.ProduceSingleBottle);
            produceSingle.Start();
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

            anim1.Completed += Anim1_Completed;

            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);
        }

        public void Anim1_Completed(object? sender, EventArgs e)
        {
            if (currentBottle.Type == BottleType.Soda)
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
            Dispatcher?.Invoke(() => { target.RenderTransform = trans; });

            DoubleAnimation anim1 = new DoubleAnimation(0, 75 - top, TimeSpan.FromSeconds(2));
            DoubleAnimation anim2 = new DoubleAnimation(315, 540 - left, TimeSpan.FromSeconds(2));

            trans.BeginAnimation(TranslateTransform.YProperty, anim1);
            trans.BeginAnimation(TranslateTransform.XProperty, anim2);

            string countSoda = SodaCounter.Text;
            int currentBeerCount = Convert.ToInt32(countSoda) + 1;
            SodaCounter.Text = currentBeerCount.ToString();
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

            string countBeer = BeerCounter.Text;
            int currentBeerCount = Convert.ToInt32(countBeer) + 1;
            BeerCounter.Text = currentBeerCount.ToString();

        }

        #region TextBox Counters
        private void SodaCounter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BeerCounter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #endregion
    }
}
