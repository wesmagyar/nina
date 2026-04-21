using System.ComponentModel;
using NINA.Avalonia.ViewModels.Utilities;

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
    
    private bool _isVersionCheckViewVisible = false;
    public bool IsVersionCheckViewVisible
    {
        get => _isVersionCheckViewVisible;
        set
        {
            _isVersionCheckViewVisible = value;
            OnPropertyChanged(nameof(IsVersionCheckViewVisible));
            OnPropertyChanged(nameof(IsHomeViewVisible));
        }
    }
    
    public bool IsHomeViewVisible => !_isAboutViewVisible && !_isCameraViewVisible && !_isVersionCheckViewVisible;
    
    public void ShowCameraView()
    {
        IsCameraViewVisible = true;
        IsAboutViewVisible = false;
        IsVersionCheckViewVisible = false;
    }
    
    public void ShowAboutView()
    {
        IsAboutViewVisible = true;
        IsCameraViewVisible = false;
        IsVersionCheckViewVisible = false;
    }
    
    public void ShowVersionCheckView()
    {
        IsVersionCheckViewVisible = true;
        IsAboutViewVisible = false;
        IsCameraViewVisible = false;
    }
    
    public void ShowHomeView()
    {
        IsAboutViewVisible = false;
        IsCameraViewVisible = false;
        IsVersionCheckViewVisible = false;
    }
}
