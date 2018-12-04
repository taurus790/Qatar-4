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
    /// Interaction logic for StationWindow.xaml
    /// </summary>
    public partial class StationWindow : Window
    {
        public GameSession GameSession => DataContext as GameSession;

        public double MouseX;
        public double MouseY;

        public StationWindow()
        {
            InitializeComponent();
        }

        private void SaveStation_Click(object sender, RoutedEventArgs e)
        {
            if (NameTxt.Text == "" || LevelTxt.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            if (GameSession.CurrentWorld != null)
            {
                GameSession.CurrentWorld.AddStation(NameTxt.Text, Convert.ToInt32(LevelTxt.Text), MouseX, MouseY);
            }

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
