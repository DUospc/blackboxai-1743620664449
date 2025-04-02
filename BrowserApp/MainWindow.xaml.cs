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

            // Handle WebView2 errors
            if (ScriptHubFrame != null)
            {
                ScriptHubFrame.NavigationFailed += (sender, e) => 
                {
                    MessageBox.Show($"Failed to load ScriptBlox: {e.Exception.Message}", 
                        "Navigation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                };
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
            try
            {
                var openFileDialog = new Microsoft.Win32.OpenFileDialog
                {
                    Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
                    Title = "Open Text File"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    EditorTextBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Error opening file: {ex.Message}", "File Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
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