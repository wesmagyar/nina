# NINA UI Port Progress

## Overview
This directory contains the progress of porting the NINA WPF application to Avalonia for cross-platform compatibility.

## Current Status
- ✅ Basic Avalonia project structure created
- ✅ Resource system implemented with brushes
- ✅ Main window rendering with custom styling
- ✅ Build system working

## Directory Structure
```
avalonia-port/
└── NINA.Avalonia/
    ├── Assets/
    ├── Resources/
    │   └── StaticResources/
    │       └── Brushes.axaml (placeholder for WPF brushes)
    ├── ViewModels/
    ├── Views/
    ├── App.axaml (main application definition)
    └── NINA.Avalonia.csproj (project file)
```

## Next Steps
1. Port WPF resource dictionaries to Avalonia format
2. Implement converter system
3. Port control templates and styles
4. Begin migrating individual views and viewmodels
5. Integrate with existing NINA business logic

## Key Differences from WPF
- Uses `.axaml` extension instead of `.xaml`
- Different binding syntax (`{DynamicResource}` instead of `{StaticResource}`)
- Simplified styling system
- Cross-platform compatibility

## Build Instructions
```bash
cd avalonia-port/NINA.Avalonia
dotnet build
dotnet run
```