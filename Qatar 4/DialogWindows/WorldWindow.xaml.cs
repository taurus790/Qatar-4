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
    /// Interaction logic for WorldWindow.xaml
    /// </summary>
    public partial class WorldWindow : Window
    {
        public GameSession GameSession => DataContext as GameSession;

        public WorldWindow()
        {
            InitializeComponent();
        }

        private void SaveWorld_Click(object sender, RoutedEventArgs e)
        {
            if (GameSession == null)
            {
                MessageBox.Show("Please create a Game first!");
                this.Close();
                return;
            }

            if (NameTxt.Text == "" || LevelTxt.Text == "" || WidthTxt.Text == ""
                || HeightTxt.Text == "" || TimeScaleTxt.Text == "")
            {
                MessageBox.Show("Please fill all fields!");
                return;
            }

            GameSession.CurrentWorld = new World(0, NameTxt.Text, Convert.ToInt32(LevelTxt.Text),
                Convert.ToInt32(WidthTxt.Text), Convert.ToInt32(HeightTxt.Text));
            GameSession.TimeScale = Convert.ToInt32(TimeScaleTxt.Text);
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
