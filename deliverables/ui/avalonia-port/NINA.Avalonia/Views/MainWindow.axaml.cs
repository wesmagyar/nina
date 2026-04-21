using Avalonia.Controls;
using Avalonia.Interactivity;

namespace NINA.Avalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    public void ShowAboutView(object sender, RoutedEventArgs e)
    {
        // Simple navigation - in a real app you'd use a proper navigation framework
        HomeView.IsVisible = false;
        AboutView.IsVisible = true;
    }
}