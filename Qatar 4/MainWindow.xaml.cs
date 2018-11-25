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
using Engine.ViewModels;

namespace Qatar_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession _gameSession;

        public MainWindow()
        {
            InitializeComponent();

            _gameSession = new GameSession();
            DataContext = _gameSession;

            //Sets Windows min size to its content
            /*SourceInitialized += (s, e) =>
            {
                MinWidth = ActualWidth;
                MinHeight = ActualHeight;
            };*/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentPlayer.Money++;
            _gameSession.CurrentStation.PosY -= 10;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentStation = _gameSession.CurrentWorld.StationWithID(_gameSession.CurrentStation.ID - 1);
            _gameSession.CurrentStation.PosX -= 15;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentStation = _gameSession.CurrentWorld.StationWithID(_gameSession.CurrentStation.ID + 1);
            _gameSession.CurrentStation.PosX += 10;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _gameSession.CurrentPlayer.Money--;
            _gameSession.CurrentStation.PosY += 10;
        }
    }
}
