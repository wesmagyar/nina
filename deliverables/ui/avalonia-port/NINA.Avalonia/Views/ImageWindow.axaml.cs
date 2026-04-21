using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace NINA.Avalonia.Views {
    public partial class ImageWindow : UserControl {
        public ImageWindow() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        private void ButtonZoomIn_Click(object sender, RoutedEventArgs e) {
            // Implementation here
        }

        private void ButtonZoomOut_Click(object sender, RoutedEventArgs e) {
            // Implementation here
        }

        private void ButtonZoomReset_Click(object sender, RoutedEventArgs e) {
            // Implementation here
        }

        private void ButtonZoomOneToOne_Click(object sender, RoutedEventArgs e) {
            // Implementation here
        }

        private void PART_Canvas_SizeChanged(object sender, SizeChangedEventArgs e) {
            // Implementation here
        }
    }
}