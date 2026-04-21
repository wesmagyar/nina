using CommunityToolkit.Mvvm.ComponentModel;

namespace NINA.Avalonia.ViewModels.Imaging {
    public partial class AnchorableCameraVM : ObservableObject {
        // Mock data for demonstration
        [ObservableProperty]
        private bool settingsVisible = true;

        [ObservableProperty]
        private string name = "ZWO ASI1600MM";

        [ObservableProperty]
        private int gain = 100;

        [ObservableProperty]
        private int offset = 10;

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
        private double targetTemp = -20.0;

        [ObservableProperty]
        private int coolingDuration = 10;

        [ObservableProperty]
        private int warmingDuration = 5;

        [ObservableProperty]
        private bool tempChangeRunning = false;

        // Profile settings mock
        [ObservableProperty]
        private ProfileSettings activeProfile = new ProfileSettings();

        public class ProfileSettings {
            public DockPanelSettings DockPanelSettings { get; set; } = new DockPanelSettings();
        }

        public class DockPanelSettings {
            public bool CameraInfoOnly { get; set; } = false;
        }
    }
}