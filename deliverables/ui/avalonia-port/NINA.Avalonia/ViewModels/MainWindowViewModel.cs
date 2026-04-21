using System.ComponentModel;

namespace NINA.Avalonia.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "NINA Avalonia Port - Basic Structure Working";
    
    private bool _isAboutViewVisible = false;
    public bool IsAboutViewVisible
    {
        get => _isAboutViewVisible;
        set
        {
            _isAboutViewVisible = value;
            OnPropertyChanged(nameof(IsAboutViewVisible));
            OnPropertyChanged(nameof(IsHomeViewVisible));
        }
    }
    
    public bool IsHomeViewVisible => !_isAboutViewVisible;
    
    public void ShowAboutView()
    {
        IsAboutViewVisible = true;
    }
    
    public void ShowHomeView()
    {
        IsAboutViewVisible = false;
    }
}
