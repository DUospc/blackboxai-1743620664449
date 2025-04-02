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

        private void OpenFile(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                EditorTextBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void OpenEdit(object sender, RoutedEventArgs e)
        {
            // Implement edit operations here
            MessageBox.Show("Edit features coming soon!", "Edit Menu", MessageBoxButton.OK);
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