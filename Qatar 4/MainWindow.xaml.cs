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
        private GameSession _gameSession;

        public MainWindow()
        {
            InitializeComponent();

            //Sets Windows min size to its content
            /*SourceInitialized += (s, e) =>
            {
                MinWidth = ActualWidth;
                MinHeight = ActualHeight;
            };*/
        }

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.DirectlyOver != (Canvas)sender) return;

            _gameSession.MapClicked(Mouse.GetPosition((Canvas)sender).X, Mouse.GetPosition((Canvas)sender).Y);
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Mouse.DirectlyOver != (Ellipse)sender) return;

            _gameSession.StationClicked(((Ellipse)sender).DataContext as Station);
        }

        private void PausePlay_Click(object sender, RoutedEventArgs e)
        {
            _gameSession.PausePlayClicked();
        }

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

        #endregion
    }
}
