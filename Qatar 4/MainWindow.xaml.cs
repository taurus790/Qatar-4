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

        private void Canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_gameSession.AddingNewStation)
            {
                _gameSession.CurrentWorld.AddStation("5", 1,
                    Mouse.GetPosition((Canvas)sender).X - 5,
                    Mouse.GetPosition((Canvas)sender).Y - 5, 50, 50);
            }
        }
    }
}
