#!/bin/bash

# NINA Linux Build Script
# This script builds NINA for Linux with INDI support

set -e  # Exit on any error

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

echo -e "${GREEN}=== NINA Linux Build Script ===${NC}"

# Check if we're running on Linux
if [[ "$OSTYPE" != "linux-gnu"* ]]; then
    echo -e "${RED}Error: This script must be run on Linux${NC}"
    exit 1
fi

# Detect distribution
if [ -f /etc/os-release ]; then
    . /etc/os-release
    DISTRO=$NAME
    VERSION=$VERSION_ID
    echo -e "${YELLOW}Detected distribution:${NC} $DISTRO $VERSION"
else
    echo -e "${RED}Error: Could not detect Linux distribution${NC}"
    exit 1
fi

# Install dependencies based on distribution
install_dependencies() {
    echo -e "${YELLOW}Installing dependencies...${NC}"
    
    if [[ $DISTRO == *"Ubuntu"* ]] || [[ $DISTRO == *"Debian"* ]]; then
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
            libgl-dev \
            libpulse-dev \
            zip \
            unzip
    elif [[ $DISTRO == *"Arch"* ]]; then
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
            pulseaudio \
            zip \
            unzip
    else
        echo -e "${RED}Unsupported distribution. Please install dependencies manually:${NC}"
        echo "- CMake 3.18+"
        echo "- .NET 8.0 SDK"
        echo "- INDI development libraries"
        echo "- libnova development libraries"
        echo "- CFITSIO development libraries"
        echo "- libusb development libraries"
        read -p "Press Enter to continue or Ctrl+C to abort" _
    fi
}

# Build native INDI bridge library
build_native_library() {
    echo -e "${YELLOW}Building native INDI bridge library...${NC}"
    
    mkdir -p build
    cd build
    
    # Configure with CMake
    cmake .. -DCMAKE_BUILD_TYPE=Release
    
    # Build
    make -j$(nproc)
    
    # Install to local directory
    make install DESTDIR=../install
    
    cd ..
}

# Build .NET application
build_dotnet_app() {
    echo -e "${YELLOW}Building .NET application...${NC}"
    
    # TODO: This will need to be updated when we have the Avalonia port
    # For now, we'll just demonstrate the build process
    
    cd ../nina
    
    # Restore NuGet packages
    dotnet restore NINA.sln
    
    # Build the application
    dotnet build NINA/NINA.csproj --configuration Release --no-restore
    
    echo -e "${GREEN}Build completed successfully!${NC}"
}

# Main execution
main() {
    # Create necessary directories
    mkdir -p ../nina-linux-port/{build,install}
    
    # Install dependencies
    install_dependencies
    
    # Build native library
    build_native_library
    
    # Build .NET application
    build_dotnet_app
    
    echo -e "${GREEN}=== Build process completed ===${NC}"
    echo -e "${YELLOW}Next steps:${NC}"
    echo "1. Package the application using packaging/create-package.sh"
    echo "2. Test the application with scripts/test.sh"
}

# Run main function
main "$@"