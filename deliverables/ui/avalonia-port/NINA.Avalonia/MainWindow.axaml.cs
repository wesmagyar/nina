using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using NINA.Avalonia.Views;

namespace NINA.Avalonia {
    public partial class MainWindow : Window {
        public MainWindow() { InitializeComponent(); }
        private void InitializeComponent() { AvaloniaXamlLoader.Load(this); }
        private void ShowAbout(object sender, RoutedEventArgs e) {
            var dialog = new AboutNINAView();
            var win = new Window { Content = dialog, Width = 400, Height = 300, Title = "About NINA" };
            win.ShowDialog(this);
        }
    }
}
