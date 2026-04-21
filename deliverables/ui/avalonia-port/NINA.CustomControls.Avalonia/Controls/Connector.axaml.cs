using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using System.Windows.Input;

namespace NINA.CustomControls.Avalonia.Controls;

public partial class Connector : UserControl
{
    public Connector()
    {
        InitializeComponent();
    }

    public static readonly StyledProperty<ICommand> ConnectCommandProperty =
        AvaloniaProperty.Register<Connector, ICommand>(nameof(ConnectCommand));

    public ICommand ConnectCommand
    {
        get => GetValue(ConnectCommandProperty);
        set => SetValue(ConnectCommandProperty, value);
    }

    public static readonly StyledProperty<ICommand> DisconnectCommandProperty =
        AvaloniaProperty.Register<Connector, ICommand>(nameof(DisconnectCommand));

    public ICommand DisconnectCommand
    {
        get => GetValue(DisconnectCommandProperty);
        set => SetValue(DisconnectCommandProperty, value);
    }

    public static readonly StyledProperty<ICommand> CancelCommandProperty =
        AvaloniaProperty.Register<Connector, ICommand>(nameof(CancelCommand));

    public ICommand CancelCommand
    {
        get => GetValue(CancelCommandProperty);
        set => SetValue(CancelCommandProperty, value);
    }

    public static readonly StyledProperty<bool> ConnectedProperty =
        AvaloniaProperty.Register<Connector, bool>(nameof(Connected));

    public bool Connected
    {
        get => GetValue(ConnectedProperty);
        set => SetValue(ConnectedProperty, value);
    }

    public static readonly StyledProperty<object> SelectedDeviceProperty =
        AvaloniaProperty.Register<Connector, object>(nameof(SelectedDevice));

    public object SelectedDevice
    {
        get => GetValue(SelectedDeviceProperty);
        set => SetValue(SelectedDeviceProperty, value);
    }

    public static readonly StyledProperty<System.Collections.IEnumerable> DevicesProperty =
        AvaloniaProperty.Register<Connector, System.Collections.IEnumerable>(nameof(Devices));

    public System.Collections.IEnumerable Devices
    {
        get => GetValue(DevicesProperty);
        set => SetValue(DevicesProperty, value);
    }

    public static readonly StyledProperty<bool> HasSetupDialogProperty =
        AvaloniaProperty.Register<Connector, bool>(nameof(HasSetupDialog));

    public bool HasSetupDialog
    {
        get => GetValue(HasSetupDialogProperty);
        set => SetValue(HasSetupDialogProperty, value);
    }

    public static readonly StyledProperty<ICommand> SetupCommandProperty =
        AvaloniaProperty.Register<Connector, ICommand>(nameof(SetupCommand));

    public ICommand SetupCommand
    {
        get => GetValue(SetupCommandProperty);
        set => SetValue(SetupCommandProperty, value);
    }

    public static readonly StyledProperty<ICommand> RefreshCommandProperty =
        AvaloniaProperty.Register<Connector, ICommand>(nameof(RefreshCommand));

    public ICommand RefreshCommand
    {
        get => GetValue(RefreshCommandProperty);
        set => SetValue(RefreshCommandProperty, value);
    }

    public static readonly StyledProperty<bool> SetupDialogOpenProperty =
        AvaloniaProperty.Register<Connector, bool>(nameof(SetupDialogOpen));

    public bool SetupDialogOpen
    {
        get => GetValue(SetupDialogOpenProperty);
        set => SetValue(SetupDialogOpenProperty, value);
    }
}