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
    
    private bool _isCameraViewVisible = false;
    public bool IsCameraViewVisible
    {
        get => _isCameraViewVisible;
        set
        {
            _isCameraViewVisible = value;
            OnPropertyChanged(nameof(IsCameraViewVisible));
            OnPropertyChanged(nameof(IsHomeViewVisible));
        }
    }
    
    public bool IsHomeViewVisible => !_isAboutViewVisible && !_isCameraViewVisible;
    
    public void ShowCameraView()
    {
        IsCameraViewVisible = true;
        IsAboutViewVisible = false;
    }
    
    public void ShowAboutView()
    {
        IsAboutViewVisible = true;
        IsCameraViewVisible = false;
    }
    
    public void ShowHomeView()
    {
        IsAboutViewVisible = false;
        IsCameraViewVisible = false;
    }
}
