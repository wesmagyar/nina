using Avalonia.Controls;
using Avalonia.Interactivity;
using NINA.Avalonia.ViewModels;

namespace NINA.Avalonia.Views;

public partial class MainWindow : Window
{
    private MainWindowViewModel _viewModel;
    
    public MainWindow()
    {
        InitializeComponent();
        _viewModel = new MainWindowViewModel();
        DataContext = _viewModel;
    }
    
    public void ShowCameraView(object sender, RoutedEventArgs e)
    {
        _viewModel.ShowCameraView();
    }
    
    public void ShowAboutView(object sender, RoutedEventArgs e)
    {
        _viewModel.ShowAboutView();
    }
    
    public void ShowVersionCheckView(object sender, RoutedEventArgs e)
    {
        _viewModel.ShowVersionCheckView();
    }
}