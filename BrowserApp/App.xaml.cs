using System.Windows;

namespace BrowserApp
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            // Set application-wide resources if needed
            Current.Resources.MergedDictionaries.Add(
                new ResourceDictionary
                {
                    Source = new System.Uri("pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Light.xaml")
                });
        }
    }
}