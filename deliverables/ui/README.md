# NINA UI Port Progress

## Overview
This directory contains the completed porting of NINA WPF camera views to Avalonia for cross-platform compatibility.

## Current Status
- ✅ Basic Avalonia project structure created
- ✅ Resource system implemented with brushes
- ✅ Main window rendering with custom styling
- ✅ Camera views successfully ported
- ✅ Build system working

## Directory Structure
```
avalonia-port/
├── NINA.Avalonia/
│   ├── Assets/
│   ├── Resources/
│   │   └── StaticResources/
│   │       └── Brushes.axaml (placeholder for WPF brushes)
│   ├── ViewModels/
│   │   └── Equipment/Camera/
│   │       ├── CameraVM.cs
│   │       └── AnchorableCameraVM.cs
│   ├── Views/
│   │   ├── Equipment/Camera/
│   │   │   └── CameraView.axaml
│   │   └── Imaging/
│   │       └── AnchorableCameraView.axaml
│   ├── App.axaml (main application definition)
│   └── NINA.Avalonia.csproj (project file)
└── NINA.CustomControls.Avalonia/
    └── Controls/
        └── Connector.axaml
```

## Completed Work
1. ✅ CameraView - Full camera device information display
2. ✅ AnchorableCameraView - Compact dockable panel version
3. ✅ CameraVM - View model with proper state management
4. ✅ AnchorableCameraVM - ViewModel for dockable panel
5. ✅ Connector control - Device connection management interface

## Key Differences from WPF
- Uses `.axaml` extension instead of `.xaml`
- Different binding syntax (`{DynamicResource}` instead of `{StaticResource}`)
- Simplified styling system with CSS-like selectors
- Cross-platform compatibility

## Build Instructions
```bash
cd avalonia-port/NINA.Avalonia
dotnet build
dotnet run
```

## Implementation Details
See `port-summary.md` for detailed implementation approach and technical decisions.