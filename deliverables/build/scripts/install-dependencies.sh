#!/bin/bash

# NINA Dependency Installation Script
# This script installs all required dependencies for building NINA on Linux

set -e  # Exit on any error

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

echo -e "${GREEN}=== NINA Dependency Installation Script ===${NC}"

# Function to detect Linux distribution
detect_distribution() {
    if [ -f /etc/os-release ]; then
        . /etc/os-release
        echo "$NAME"
    else
        echo "Unknown"
    fi
}

# Install dependencies for Ubuntu/Debian
install_ubuntu_debian() {
    echo -e "${YELLOW}Installing dependencies for Ubuntu/Debian...${NC}"
    
    sudo apt-get update
    
    # Install build tools
    sudo apt-get install -y \
        build-essential \
        cmake \
        pkg-config \
        ninja-build
    
    # Install .NET SDK
    sudo apt-get install -y dotnet-sdk-8.0
    
    # Install INDI and astronomy libraries
    sudo apt-get install -y \
        libindi-dev \
        libnova-dev \
        libcfitsio-dev \
        libusb-1.0-0-dev
    
    # Install GUI libraries for Avalonia
    sudo apt-get install -y \
        libgtk-3-dev \
        librsvg2-dev \
        libxt-dev \
        libx11-dev \
        libgl1-mesa-dev \
        libpulse-dev
    
    # Install packaging tools
    sudo apt-get install -y \
        zip \
        unzip \
        debhelper
    
    # Install development tools
    sudo apt-get install -y \
        git \
        curl \
        jq
    
    echo -e "${GREEN}Dependencies installed successfully${NC}"
}

# Install dependencies for Arch Linux
install_arch() {
    echo -e "${YELLOW}Installing dependencies for Arch Linux...${NC}"
    
    # Update system
    sudo pacman -Syu --noconfirm
    
    # Install build tools
    sudo pacman -S --noconfirm \
        base-devel \
        cmake \
        pkgconf \
        ninja
    
    # Install .NET SDK
    sudo pacman -S --noconfirm \
        dotnet-host \
        dotnet-runtime \
        dotnet-sdk
    
    # Install INDI and astronomy libraries
    sudo pacman -S --noconfirm \
        indi \
        libnova \
        cfitsio \
        libusb
    
    # Install GUI libraries for Avalonia
    sudo pacman -S --noconfirm \
        gtk3 \
        librsvg \
        libxt \
        libx11 \
        mesa \
        pulseaudio
    
    # Install packaging tools
    sudo pacman -S --noconfirm \
        zip \
        unzip
    
    # Install development tools
    sudo pacman -S --noconfirm \
        git \
        curl \
        jq
    
    echo -e "${GREEN}Dependencies installed successfully${NC}"
}

# Install dependencies for Fedora
install_fedora() {
    echo -e "${YELLOW}Installing dependencies for Fedora...${NC}"
    
    # Install build tools
    sudo dnf install -y \
        gcc-c++ \
        cmake \
        pkgconfig \
        ninja-build
    
    # Install .NET SDK
    sudo dnf install -y dotnet-sdk-8.0
    
    # Install INDI and astronomy libraries
    sudo dnf install -y \
        indi-devel \
        libnova-devel \
        cfitsio-devel \
        libusb1-devel
    
    # Install GUI libraries for Avalonia
    sudo dnf install -y \
        gtk3-devel \
        librsvg2-devel \
        libXt-devel \
        libX11-devel \
        mesa-libGL-devel \
        pulseaudio-libs-devel
    
    # Install packaging tools
    sudo dnf install -y \
        zip \
        unzip \
        rpm-build
    
    # Install development tools
    sudo dnf install -y \
        git \
        curl \
        jq
    
    echo -e "${GREEN}Dependencies installed successfully${NC}"
}

# Main execution
main() {
    DISTRO=$(detect_distribution)
    echo -e "${YELLOW}Detected distribution:${NC} $DISTRO"
    
    case $DISTRO in
        *"Ubuntu"*|*"Debian"*)
            install_ubuntu_debian
            ;;
        *"Arch"*)
            install_arch
            ;;
        *"Fedora"*)
            install_fedora
            ;;
        *)
            echo -e "${RED}Unsupported distribution: $DISTRO${NC}"
            echo "Please install dependencies manually:"
            echo "- CMake 3.18+"
            echo "- .NET 8.0 SDK"
            echo "- INDI development libraries"
            echo "- libnova development libraries"
            echo "- CFITSIO development libraries"
            echo "- libusb development libraries"
            echo "- GTK3 development libraries"
            exit 1
            ;;
    esac
}

# Run main function
main "$@"