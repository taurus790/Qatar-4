using Engine.Models;
using Engine.ViewModels;
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
using System.Windows.Shapes;

namespace Qatar_4.DialogWindows
{
    /// <summary>
    /// Interaction logic for WayWindow.xaml
    /// </summary>
    public partial class WayWindow : Window
    {
        public GameSession GameSession => DataContext as GameSession;
        public Station clickedStation;

        public WayWindow()
        {
            InitializeComponent();
        }

        private void SaveWay_Click(object sender, RoutedEventArgs e)
        {
            GameSession.CurrentWorld.AddWay(NameTxt.Text, Convert.ToInt32(LevelTxt.Text), GameSession.CurrentStation, clickedStation);

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
