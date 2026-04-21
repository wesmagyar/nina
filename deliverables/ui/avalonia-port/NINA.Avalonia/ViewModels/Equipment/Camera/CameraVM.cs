using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NINA.Avalonia.ViewModels.Equipment.Camera;

public partial class CameraVM : ViewModelBase
{
    [ObservableProperty]
    private string _cameraName = "ZWO ASI1600MM-Cool";

    [ObservableProperty]
    private string _cameraDescription = "High-quality astronomy camera with cooling";

    [ObservableProperty]
    private string _driverInfo = "ZWO ASI Camera Driver v1.0";

    [ObservableProperty]
    private string _driverVersion = "1.0.0";

    [ObservableProperty]
    private string _sensorType = "CMOS";

    [ObservableProperty]
    private string _sensorName = "Sony IMX378";

    [ObservableProperty]
    private int _cameraXSize = 4656;

    [ObservableProperty]
    private int _cameraYSize = 3522;

    [ObservableProperty]
    private double _pixelSizeX = 3.8;

    [ObservableProperty]
    private double _pixelSizeY = 3.8;

    [ObservableProperty]
    private double _minExposure = 0.001;

    [ObservableProperty]
    private double _maxExposure = 3600;

    [ObservableProperty]
    private int _maxBinX = 4;

    [ObservableProperty]
    private int _maxBinY = 4;

    [ObservableProperty]
    private bool _connected = false;

    [ObservableProperty]
    private double _temperature = 15.2;

    [ObservableProperty]
    private double _targetTemperature = -10.0;

    [ObservableProperty]
    private bool _coolerOn = true;

    [ObservableProperty]
    private double _coolerPower = 85.3;

    [ObservableProperty]
    private bool _hasDewHeater = true;

    [ObservableProperty]
    private bool _dewHeaterOn = false;

    [ObservableProperty]
    private int _defaultGain = 100;

    [ObservableProperty]
    private int _gainMin = 0;

    [ObservableProperty]
    private int _gainMax = 400;

    public ObservableCollection<string> ReadoutModes { get; } = new()
    {
        "Normal",
        "Fast Readout",
        "High Quality"
    };

    [ObservableProperty]
    private int _selectedReadoutMode = 0;

    public CameraVM()
    {
    }

    [RelayCommand]
    private void Connect()
    {
        Connected = true;
    }

    [RelayCommand]
    private void Disconnect()
    {
        Connected = false;
    }

    [RelayCommand]
    private void ToggleDewHeater()
    {
        DewHeaterOn = !DewHeaterOn;
    }

    [RelayCommand]
    private void ToggleCooler()
    {
        CoolerOn = !CoolerOn;
    }

    [RelayCommand]
    private void SetTargetTemperature()
    {
        // In a real implementation, this would send the temperature command to the camera
    }
}