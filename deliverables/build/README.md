# NINA Linux Port - Build System

This directory contains the cross-platform build system for porting NINA (Nighttime Imaging 'N' Astronomy) to Linux.

## Overview

NINA is a modular astrophotography suite originally designed for Windows. This build system enables NINA to run on Linux distributions with INDI (Instrument Neutral Distributed Interface) support.

## Directory Structure

```
nina-linux-port/
├── CMakeLists.txt          # CMake configuration for native INDI bridge
├── cmake/                  # CMake modules and configuration files
├── src/                    # Native C++ source code for INDI bridge
├── include/                # C++ header files for INDI bridge
├── scripts/                # Build and utility scripts
├── packaging/              # Packaging scripts for distribution
├── docker/                 # Docker configuration for containerized builds
└── dist/                   # Generated packages and distributions
```

## Prerequisites

### Supported Linux Distributions

- Ubuntu 22.04+
- Debian 11+
- Arch Linux
- Fedora 35+

### Required Dependencies

- CMake 3.18+
- .NET 8.0 SDK
- INDI development libraries
- libnova development libraries
- CFITSIO development libraries
- libusb development libraries
- GTK3 development libraries (for Avalonia)

## Building NINA for Linux

### Automated Installation

```bash
# Clone the repository
git clone https://github.com/isbeorn/nina.git
cd nina

# Install dependencies automatically
./nina-linux-port/scripts/install-dependencies.sh

# Build the project
./nina-linux-port/scripts/build.sh
```

### Manual Installation

#### Ubuntu/Debian

```bash
sudo apt-get update
sudo apt-get install -y \
    cmake \
    pkg-config \
    libindi-dev \
    libnova-dev \
    libcfitsio-dev \
    libusb-1.0-0-dev \
    dotnet-sdk-8.0 \
    libgtk-3-dev \
    librsvg2-dev \
    libxt-dev \
    libx11-dev \
    libgl1-mesa-dev \
    libpulse-dev
```

#### Arch Linux

```bash
sudo pacman -Syu --noconfirm \
    cmake \
    pkgconf \
    indi \
    libnova \
    cfitsio \
    libusb \
    dotnet-host \
    dotnet-runtime \
    dotnet-sdk \
    gtk3 \
    librsvg \
    libxt \
    libx11 \
    mesa \
    pulseaudio
```

### Build Process

```bash
# Build native INDI bridge library
mkdir -p build
cd build
cmake .. -DCMAKE_BUILD_TYPE=Release
make -j$(nproc)
cd ..

# Build .NET application
cd nina
dotnet restore NINA.sln
dotnet build NINA/NINA.csproj --configuration Release --no-restore
```

## Docker Build Environment

A Docker container is provided for consistent builds across different environments:

```bash
cd nina-linux-port/docker
docker-compose run nina-build
```

## Testing

Run tests to verify the build:

```bash
./nina-linux-port/scripts/test.sh
```

## Packaging

Create distributable packages:

```bash
./nina-linux-port/packaging/create-package.sh
```

Supported package formats:
- AppImage (universal Linux package)
- Debian package (.deb)
- Tarball archive

## CI/CD Pipeline

GitHub Actions are configured to automatically build and test on pushes to main and develop branches.

## Troubleshooting

### Common Issues

1. **Missing dependencies**: Run `install-dependencies.sh` to automatically install all required packages.

2. **.NET SDK not found**: Ensure the .NET 8.0 SDK is installed and accessible in PATH.

3. **INDI connection issues**: Verify that the INDI server is running and accessible.

### Getting Help

- Check the [NINA documentation](https://nighttime-imaging.eu/docs/)
- Visit the [NINA Discord](https://discord.gg/nighttime-imaging)
- File issues on the [GitHub repository](https://github.com/isbeorn/nina/issues)

## Contributing

See [CONTRIBUTING.md](../CONTRIBUTING.md) for guidelines on contributing to the project.