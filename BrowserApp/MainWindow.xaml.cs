using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Wpf.UI.Controls;

namespace BrowserApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            webView.NavigationStarting += WebView_NavigationStarting;
            webView.NavigationCompleted += WebView_NavigationCompleted;
        }

        private void WebView_NavigationStarting(object sender, WebViewNavigationStartingEventArgs e)
        {
            txtAddress.Text = e.Uri?.ToString() ?? "about:blank";
        }

        private void WebView_NavigationCompleted(object sender, WebViewNavigationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                MessageBox.Show($"Failed to load {e.Uri}", "Navigation Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CanGoBack)
                webView.GoBack();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (webView.CanGoForward)
                webView.GoForward();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            webView.Refresh();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            NavigateToAddress();
        }

        private void txtAddress_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                NavigateToAddress();
            }
        }

        private void NavigateToAddress()
        {
            var address = txtAddress.Text;
            if (!address.StartsWith("http://") && !address.StartsWith("https://"))
            {
                address = "https://" + address;
            }
            try
            {
                webView.Source = new Uri(address);
            }
            catch (UriFormatException)
            {
                MessageBox.Show("Invalid URL format", "Error", 
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnNewTab_Click(object sender, RoutedEventArgs e)
        {
            var newTab = new TabItem();
            newTab.Header = "New Tab";
            
            var newWebView = new WebView();
            newWebView.Source = new Uri("https://www.google.com");
            newWebView.NavigationStarting += WebView_NavigationStarting;
            newWebView.NavigationCompleted += WebView_NavigationCompleted;
            
            newTab.Content = newWebView;
            tabControl.Items.Add(newTab);
            tabControl.SelectedItem = newTab;
        }
    }
}