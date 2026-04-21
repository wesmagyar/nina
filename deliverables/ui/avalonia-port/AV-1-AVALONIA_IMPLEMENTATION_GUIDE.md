# AV-1: Avalonia Implementation Guide for NINA Port

## Overview
This document provides technical guidance for porting NINA from WPF to Avalonia, leveraging the existing .NET codebase while adapting the UI layer for cross-platform compatibility.

## Key Advantages of Avalonia for NINA

1. **XAML Compatibility**: High degree of compatibility with WPF XAML means mechanical porting is possible
2. **.NET Preservation**: All C# business logic, MEF plugins, and existing architecture remain intact
3. **Cross-Platform**: Enables Linux, macOS, and Windows support from a single codebase
4. **Community Toolkit**: Supports modern MVVM patterns through CommunityToolkit.Mvvm

## Architecture Mapping

### WPF to Avalonia Equivalents

| WPF Component | Avalonia Equivalent | Notes |
|---------------|---------------------|-------|
| UserControl | UserControl | Direct equivalent |
| Window | Window | Direct equivalent |
| DataTemplate | DataTemplate | Syntax differences |
| Style/ResourceDictionary | Fluent Theme/Styles | Different theming approach |
| Binding | Binding | Similar syntax, enhanced features |
| Commands | CommunityToolkit.RelayCommand | Better implementation |

### Project Structure Adaptation

```
NINA.Avalonia/
├── ViewModels/          # MVVM ViewModels (similar to existing)
├── Views/               # AXAML views (replaces XAML)
├── Assets/              # Images, icons, fonts
├── Services/            # Platform-specific services
├── Converters/          # Value converters
└── Controls/            # Custom controls
```

## Implementation Strategy

### Phase 1: Core UI Elements
1. Main application window and shell
2. Menu system and navigation
3. Basic docking framework
4. Core dialogs and messages

### Phase 2: Equipment UI Components
1. Camera control panels
2. Telescope/mount interfaces
3. Focuser and filter wheel controls
4. Sequencer UI elements

### Phase 3: Advanced Features
1. Image display and analysis windows
2. Plotting and charting components
3. Custom controls and themes
4. Plugin integration points

## Technical Considerations

### XAML Conversion Guidelines
1. Replace `xmlns` declarations with Avalonia equivalents
2. Update namespaces from `System.Windows.*` to `Avalonia.*`
3. Replace WPF-specific markup extensions where needed
4. Adapt styling to use Fluent theme or custom themes

### Data Binding Differences
```xml
<!-- WPF -->
<TextBlock Text="{Binding Path=PropertyName}" />

<!-- Avalonia -->
<TextBlock Text="{Binding PropertyName}" />
```

### Resource Management
1. Use `AvaloniaResource` instead of `ResourceDictionary`
2. Update image paths and asset references
3. Adapt styling to Avalonia's theme system

### Custom Controls Migration
Many custom controls in `NINA.CustomControlLibrary` will need adaptation:
1. Inherit from Avalonia controls instead of WPF
2. Update property notification mechanisms
3. Adapt rendering and drawing code to Avalonia APIs

## Integration Points

### MEF Plugin System
The existing MEF-based plugin architecture should work with minimal changes:
1. Plugins can continue to export ViewModels and services
2. UI composition points need Avalonia adaptations
3. Resource dictionaries in plugins need conversion

### Dependency Injection
Continue using existing DI patterns with Microsoft.Extensions.DependencyInjection:
1. Register Avalonia services alongside existing services
2. Adapt lifetime management for platform-specific services

### Threading and Async Patterns
Avalonia's threading model is similar to WPF:
1. UI thread access through `Dispatcher.UIThread`
2. Background operations follow existing patterns
3. Async/await patterns remain unchanged

## Build and Deployment

### Target Frameworks
- Target: `net10.0` for cross-platform compatibility
- Runtime identifiers: `win-x64`, `linux-x64`, `osx-x64`

### Packaging Considerations
1. Avalonia supports self-contained deployment
2. Native dependencies need platform-specific handling
3. AppImage/Snap packaging for Linux distributions

## Testing Strategy

### Unit Testing
Existing unit tests should largely remain unchanged since business logic is preserved.

### UI Testing
Consider using Avalonia's testing utilities:
1. `Avalonia.UnitTests` for headless UI testing
2. Visual tree verification for control rendering
3. Input simulation for interaction testing

## Risk Mitigation

### Major Risks
1. **Performance**: Initial Avalonia versions may have performance gaps compared to WPF
2. **Theming**: Visual consistency with original NINA may require significant effort
3. **Third-party Controls**: Some WPF controls may not have Avalonia equivalents

### Mitigation Approaches
1. Profile performance early and optimize hot paths
2. Create design specs to match original styling
3. Identify alternative controls or implement missing ones as needed

## Next Steps for Implementation

1. Complete basic project setup (✓ Done)
2. Port main application shell and navigation
3. Migrate core equipment control panels
4. Adapt custom controls from NINA.CustomControlLibrary
5. Integrate with existing business logic layers
6. Validate plugin compatibility
7. Performance tuning and optimization

## References

1. https://docs.avaloniaui.net/
2. https://docs.avaloniaui.net/guides/basics/migration-guide-from-wpf
3. https://docs.avaloniaui.net/reference/templates/differences-between-avalonia-and-wpf

---
Document Version: 1.0
Created: 2026-04-21
Author: CTO