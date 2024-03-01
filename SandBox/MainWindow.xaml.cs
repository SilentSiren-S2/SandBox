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

        private void btnSample2_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
