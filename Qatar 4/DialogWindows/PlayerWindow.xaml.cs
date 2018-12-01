using Engine.ViewModels;
using Engine.Models;
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
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        public GameSession GameSession => DataContext as GameSession;

        public PlayerWindow()
        {
            InitializeComponent();
        }

        private void SavePlayer_Click(object sender, RoutedEventArgs e)
        {
            if (GameSession == null)
            {
                MessageBox.Show("Please create a Game first!");
                this.Close();
                return;
            }

            if (NameTxt.Text == "" || LevelTxt.Text == "" || MoneyTxt.Text == "" || ImageSourceTxt.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            GameSession.CurrentPlayer = new Player(NameTxt.Text, Convert.ToInt32(LevelTxt.Text),
                Convert.ToInt32(MoneyTxt.Text), ImageSourceTxt.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
