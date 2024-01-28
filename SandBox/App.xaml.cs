using SandBox.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SandBox
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private List<View.WUniv> UnivWindow = new List<View.WUniv>();

        public List<View.WUniv> CreateUnivWindows
        {
            get { return UnivWindow; }
            set { UnivWindow = value; }
        }

        private List<View.WStudent> StudWindow = new List<View.WStudent>();
    }
}
