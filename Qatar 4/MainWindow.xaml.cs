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
using Engine.Models;
using Engine.ViewModels;
using Qatar_4.DialogWindows;

namespace Qatar_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Public properties 

        public GameSession _gameSession;

        #endregion

        #region Constructor 

        public MainWindow()
        {
            InitializeComponent();

            // Create a Game
            _gameSession = new GameSession();
            DataContext = _gameSession;


            //Sets Windows min size to its content
            /*SourceInitialized += (s, e) =>
            {
                MinWidth = ActualWidth;
                MinHeight = ActualHeight;
            };*/
        }

        #endregion

        #region UI input 

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.DirectlyOver != (Canvas)sender) return;

            _gameSession.ClearSelecteds();

            if (_gameSession.AddingNewStation)
            {
                StationWindow stationWindow = new StationWindow();
                stationWindow.Owner = this;
                stationWindow.DataContext = _gameSession;
                stationWindow.MouseX = Mouse.GetPosition((Canvas)sender).X;
                stationWindow.MouseY = Mouse.GetPosition((Canvas)sender).Y;
                stationWindow.ShowDialog();
            }
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.DirectlyOver != (Ellipse)sender) return;

            Station clickedStation = ((Ellipse)sender).DataContext as Station;

            if (_gameSession.CurrentStation == null)
            {
                _gameSession.ClearSelecteds();
                _gameSession.CurrentStation = clickedStation;
            }
            else if (_gameSession.AddingNewWay && 
                _gameSession.CurrentStation != clickedStation && 
                !_gameSession.AreConnected(_gameSession.CurrentStation, clickedStation))
            {

                WayWindow wayWindow = new WayWindow();
                wayWindow.Owner = this;
                wayWindow.DataContext = _gameSession;
                wayWindow.clickedStation = clickedStation;
                wayWindow.ShowDialog();

                _gameSession.CurrentStation = clickedStation;
            }
            else
            {
                _gameSession.CurrentStation = clickedStation;
            }
        }

        private void PausePlay_Click(object sender, RoutedEventArgs e)
        {
            _gameSession.PausePlayClicked();
        }

        #endregion

        #region Menu

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            _gameSession = new GameSession();
            DataContext = _gameSession;
        }

        private void NewPlayer_Click(object sender, RoutedEventArgs e)
        {
            PlayerWindow playerWindow = new PlayerWindow();
            playerWindow.Owner = this;
            playerWindow.DataContext = _gameSession;
            playerWindow.ShowDialog();
        }

        private void NewWorld_Click(object sender, RoutedEventArgs e)
        {
            WorldWindow worldWindow = new WorldWindow();
            worldWindow.Owner = this;
            worldWindow.DataContext = _gameSession;
            worldWindow.ShowDialog();
        }
        
        #endregion
    }
}
