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

            Thread t = new Thread(mana.GenerateBottle);

            t.Start();

            mana.bottleHandlerEvent += Mana_bottleHandlerEvent;
        }

        private void Mana_bottleHandlerEvent(object? sender, EventArgs e)
        {
            Debug.WriteLine("Bottle received");
        }

        private void SingleBottle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MultipleBottles_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SodaCounter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void BeerCounter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
