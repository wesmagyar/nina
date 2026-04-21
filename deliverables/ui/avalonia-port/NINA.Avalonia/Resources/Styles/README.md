# Avalonia Styles Porting Guide

This directory contains Avalonia UI styles that are ported from the original WPF styles.

## Porting Status

✅ Button.axaml - Ported from NINA.WPF.Base/Resources/Styles/Button.xaml
◻ CheckBox.axaml - TODO
◻ ComboBox.axaml - TODO
◻ DataGrid.axaml - TODO
◻ TextBox.axaml - TODO
... (other styles to be ported)

## Key Differences from WPF

1. **Namespace**: Uses `https://github.com/avaloniaui` instead of `http://schemas.microsoft.com/winfx/2006/xaml/presentation`
2. **Resource References**: Uses `DynamicResource` instead of `StaticResource`
3. **Triggers**: Uses CSS-like selectors (`Style Selector="^:pointerover"`) instead of WPF triggers
4. **ControlTemplate**: Simplified structure with `ControlTemplate` element directly containing the visual tree
5. **Property Names**: Some property names may differ (e.g., `CornerRadius` vs border radius properties)

## Usage

Styles are automatically loaded through the App.axaml file:

```xml
<Application.Styles>
    <FluentTheme />
    <StyleInclude Source="/Resources/Styles/Button.axaml"/>
</Application.Styles>
```

## Next Steps

1. Continue porting remaining style files from `NINA.WPF.Base/Resources/Styles/`
2. Test each ported style in a sample view
3. Ensure visual consistency with original WPF appearance
4. Optimize for Avalonia-specific performance patterns