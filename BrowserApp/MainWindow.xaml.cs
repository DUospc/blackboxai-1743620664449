using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace BrowserApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += (s, e) => DragMove();
            
            // Initialize settings
            if (TransparencySlider != null)
            {
                TransparencySlider.ValueChanged += (s, e) => 
                    this.Opacity = TransparencySlider.Value;
            }
        }

        private void MinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = this.WindowState == WindowState.Maximized 
                ? WindowState.Normal 
                : WindowState.Maximized;
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OpenSettings(object sender, RoutedEventArgs e)
        {
            if (SettingsPanel != null)
                SettingsPanel.Visibility = Visibility.Visible;
        }

        private void CloseSettings(object sender, RoutedEventArgs e)
        {
            if (SettingsPanel != null)
                SettingsPanel.Visibility = Visibility.Collapsed;
        }
    }
}