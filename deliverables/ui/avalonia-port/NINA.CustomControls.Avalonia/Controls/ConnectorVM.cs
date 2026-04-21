using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Media;

namespace NINA.CustomControls.Avalonia.Controls {
    public partial class ConnectorVM : ObservableObject {
        [ObservableProperty]
        private string connectButtonText = "Connect";

        [ObservableProperty]
        private string connectButtonToolTip = "Connect to device";

        [ObservableProperty]
        private bool hasSetupDialog = false;

        [ObservableProperty]
        private bool connected = false;

        [ObservableProperty]
        private string connectionStatusText = "Disconnected";

        [ObservableProperty]
        private IBrush connectionStatusColor = Brushes.Red;

        [ObservableProperty]
        private object selectedDevice = "No devices found";

        // Commands would be implemented here in a real implementation
        public object RefreshCommand => null;
        public object ConnectToggleCommand => null;
        public object SetupCommand => null;
        
        // Devices collection
        public object Devices => new string[] { "Device 1", "Device 2", "Device 3" };
    }
}