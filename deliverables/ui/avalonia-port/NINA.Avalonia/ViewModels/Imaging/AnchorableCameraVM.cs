using CommunityToolkit.Mvvm.ComponentModel;

namespace NINA.Avalonia.ViewModels.Imaging;

public partial class AnchorableCameraVM : ViewModelBase
{
    [ObservableProperty]
    private bool _settingsVisible = true;

    [ObservableProperty]
    private bool _connected = true;

    [ObservableProperty]
    private bool _canGetGain = true;

    [ObservableProperty]
    private int _gain = 100;

    [ObservableProperty]
    private bool _canSetOffset = true;

    [ObservableProperty]
    private int _offset = 10;

    [ObservableProperty]
    private bool _hasBattery = true;

    [ObservableProperty]
    private double _battery = 85.5;

    [ObservableProperty]
    private bool _hasDewHeater = true;

    [ObservableProperty]
    private bool _dewHeaterOn = false;

    [ObservableProperty]
    private bool _canSetTemperature = true;

    [ObservableProperty]
    private bool _coolerOn = true;

    [ObservableProperty]
    private double _coolerPower = 75.2;

    [ObservableProperty]
    private double _temperature = -8.5;

    [ObservableProperty]
    private double _temperatureSetPoint = -10.0;

    public AnchorableCameraVM()
    {
    }
}