using SandBox.Engine.VEngine;
using SandBox.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace SandBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            WUniv univ = new WUniv();
            univ.Owner = this;
            univ.ShowDialog();

            (Application.Current as App).CreateUnivWindows.Add(univ);
        }

        private void EngineButton_Click(object sender, RoutedEventArgs e)
        {
            FightZone fightZone = new FightZone();
            fightZone.ShowDialog();
        }

        private void DeadInside_Click(object sender, RoutedEventArgs e)
        {
            DeadInside4.MainWindow mainWindow = new DeadInside4.MainWindow();
            mainWindow.Show();
        }

        private void EngineButton2_Click(object sender, RoutedEventArgs e)
        {
            FightZone2 fightZone = new FightZone2();
            fightZone.ShowDialog();
        }
    }
}
