using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;

namespace NINA.Avalonia.ViewModels.Equipment.Camera {
    public partial class CameraVM : ObservableObject {
        // Mock data for demonstration
        [ObservableProperty]
        private string name = "ZWO ASI1600MM";

        [ObservableProperty]
        private string description = "ASICCD Interface Camera";

        [ObservableProperty]
        private string driverInfo = "ZWO ASI Camera Driver";

        [ObservableProperty]
        private string driverVersion = "1.0.0.0";

        [ObservableProperty]
        private string sensorType = "Color SCMOS";

        [ObservableProperty]
        private int cameraXSize = 4096;

        [ObservableProperty]
        private int cameraYSize = 4096;

        [ObservableProperty]
        private double pixelSizeX = 3.8;

        [ObservableProperty]
        private double pixelSizeY = 3.8;

        [ObservableProperty]
        private double exposureMin = 0.001;

        [ObservableProperty]
        private double exposureMax = 3600;

        [ObservableProperty]
        private int maxBinX = 4;

        [ObservableProperty]
        private int maxBinY = 4;

        [ObservableProperty]
        private int gain = 100;

        [ObservableProperty]
        private int gainMin = 0;

        [ObservableProperty]
        private int gainMax = 400;

        [ObservableProperty]
        private int offset = 10;

        [ObservableProperty]
        private int offsetMin = 0;

        [ObservableProperty]
        private int offsetMax = 100;

        [ObservableProperty]
        private bool canGetGain = true;

        [ObservableProperty]
        private bool canSetOffset = true;

        [ObservableProperty]
        private bool canSetTemperature = true;

        [ObservableProperty]
        private bool connected = true;

        [ObservableProperty]
        private double temperature = -15.5;

        [ObservableProperty]
        private double temperatureSetPoint = -20.0;

        [ObservableProperty]
        private bool coolerOn = true;

        [ObservableProperty]
        private double coolerPower = 85.2;

        [ObservableProperty]
        private bool hasDewHeater = true;

        [ObservableProperty]
        private bool dewHeaterOn = true;

        [ObservableProperty]
        private bool cameraStateChanged = false;

        [ObservableProperty]
        private string cameraState = "Idle";

        [ObservableProperty]
        private int defaultGain = 100;

        [ObservableProperty]
        private int defaultOffset = 10;

        [ObservableProperty]
        private double targetTemp = -20.0;

        [ObservableProperty]
        private int coolingDuration = 10;

        [ObservableProperty]
        private int warmingDuration = 5;

        [ObservableProperty]
        private bool tempChangeRunning = false;

        [ObservableProperty]
        private ObservableCollection<string> devices = new ObservableCollection<string> {
            "ZWO ASI1600MM",
            "ZWO ASI294MC",
            "QHY QHY16200"
        };

        [ObservableProperty]
        private string selectedDevice = "ZWO ASI1600MM";
    }
}