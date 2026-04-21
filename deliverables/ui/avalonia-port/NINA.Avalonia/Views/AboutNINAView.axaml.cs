using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace NINA.Avalonia.Views {
    public partial class AboutNINAView : UserControl {
        public AboutNINAView() { InitializeComponent(); }
        private void InitializeComponent() { AvaloniaXamlLoader.Load(this); }
    }
}
