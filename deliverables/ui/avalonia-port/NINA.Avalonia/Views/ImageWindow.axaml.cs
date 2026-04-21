using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NINA.Avalonia.Views {
    public partial class ImageWindow : UserControl {
        public ImageWindow() {
            InitializeComponent();
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
