#!/bin/bash

# NINA Linux Packaging Script
# This script creates distributable packages for Linux

set -e  # Exit on any error

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

echo -e "${BLUE}=== NINA Linux Packaging Script ===${NC}"

# Check if build exists
if [ ! -d "../build" ]; then
    echo -e "${RED}Error: Build directory not found. Please run build.sh first.${NC}"
    exit 1
fi

# Create directories for packaging
PACKAGE_DIR="../dist"
mkdir -p "$PACKAGE_DIR"

# Create AppImage package
create_appimage() {
    echo -e "${YELLOW}Creating AppImage package...${NC}"
    
    # Create AppDir structure
    APPDIR="$PACKAGE_DIR/NINA.AppDir"
    mkdir -p "$APPDIR"
    
    # Copy application binaries
    cp -r ../install/* "$APPDIR/"
    
    # Copy desktop file
    cp nina.desktop "$APPDIR/"
    
    # Copy icon
    cp nina-icon.png "$APPDIR/"
    
    # Download linuxdeploy if not present
    if [ ! -f linuxdeploy-x86_64.AppImage ]; then
        wget https://github.com/linuxdeploy/linuxdeploy/releases/download/continuous/linuxdeploy-x86_64.AppImage
        chmod +x linuxdeploy-x86_64.AppImage
    fi
    
    # Create AppImage
    ./linuxdeploy-x86_64.AppImage \
        --appdir "$APPDIR" \
        --output appimage \
        --icon-file=nina-icon.png \
        --desktop-file=nina.desktop
    
    echo -e "${GREEN}AppImage created successfully${NC}"
}

# Create Debian package
create_deb() {
    echo -e "${YELLOW}Creating Debian package...${NC}"
    
    DEB_DIR="$PACKAGE_DIR/debian"
    mkdir -p "$DEB_DIR/NINA/usr/bin"
    mkdir -p "$DEB_DIR/NINA/usr/lib/nina"
    mkdir -p "$DEB_DIR/NINA/usr/share/applications"
    mkdir -p "$DEB_DIR/NINA/usr/share/icons/hicolor/256x256/apps"
    mkdir -p "$DEB_DIR/NINA/DEBIAN"
    
    # Copy application files
    cp -r ../install/* "$DEB_DIR/NINA/usr/lib/nina/"
    
    # Create symlink in /usr/bin
    ln -s /usr/lib/nina/NINA "$DEB_DIR/NINA/usr/bin/nina"
    
    # Copy desktop file
    cp nina.desktop "$DEB_DIR/NINA/usr/share/applications/"
    
    # Copy icon
    cp nina-icon.png "$DEB_DIR/NINA/usr/share/icons/hicolor/256x256/apps/nina.png"
    
    # Create control file
    cat > "$DEB_DIR/NINA/DEBIAN/control" << EOF
Package: nina
Version: 1.0.0
Section: graphics
Priority: optional
Architecture: amd64
Depends: libindi-dev, libnova-dev, libcfitsio-dev, libusb-1.0-0-dev
Maintainer: NINA Team <support@nighttime-imaging.eu>
Description: Nighttime Imaging 'N' Astronomy
 A modular astrophotography suite designed to simplify and streamline image acquisition.
EOF
    
    # Create postinst script
    cat > "$DEB_DIR/NINA/DEBIAN/postinst" << EOF
#!/bin/bash
chmod +x /usr/lib/nina/NINA
EOF
    
    chmod +x "$DEB_DIR/NINA/DEBIAN/postinst"
    
    # Create package
    dpkg-deb --build "$DEB_DIR/NINA" "$PACKAGE_DIR/nina_1.0.0_amd64.deb"
    
    echo -e "${GREEN}Debian package created successfully${NC}"
}

# Create tarball package
create_tarball() {
    echo -e "${YELLOW}Creating tarball package...${NC}"
    
    TAR_DIR="$PACKAGE_DIR/nina-1.0.0"
    mkdir -p "$TAR_DIR"
    
    # Copy application files
    cp -r ../install/* "$TAR_DIR/"
    
    # Create install script
    cat > "$TAR_DIR/install.sh" << 'EOF'
#!/bin/bash
# NINA Installation Script for Linux

set -e

echo "Installing NINA..."

# Create installation directory
sudo mkdir -p /opt/nina

# Copy files
sudo cp -r * /opt/nina/

# Create symlink
sudo ln -sf /opt/nina/NINA /usr/local/bin/nina

# Create desktop entry
sudo tee /usr/share/applications/nina.desktop > /dev/null << 'DESKTOP'
[Desktop Entry]
Name=NINA - Nighttime Imaging 'N' Astronomy
Comment=A modular astrophotography suite
Exec=/opt/nina/NINA
Icon=/opt/nina/nina-icon.png
Terminal=false
Type=Application
Categories=Graphics;Astronomy;
DESKTOP

echo "Installation complete!"
echo "Run 'nina' from the terminal or find it in your applications menu."
EOF

    chmod +x "$TAR_DIR/install.sh"
    
    # Create tarball
    cd "$PACKAGE_DIR"
    tar -czf "nina-1.0.0.tar.gz" "$(basename "$TAR_DIR")"
    
    echo -e "${GREEN}Tarball package created successfully${NC}"
}

# Main execution
main() {
    # Create necessary directories
    mkdir -p "$PACKAGE_DIR"
    
    # Create desktop file
    cat > nina.desktop << EOF
[Desktop Entry]
Name=NINA - Nighttime Imaging 'N' Astronomy
Comment=A modular astrophotography suite
Exec=NINA
Icon=nina-icon
Terminal=false
Type=Application
Categories=Graphics;Astronomy;
EOF
    
    # Create placeholder icon (in real implementation, this would be a real PNG)
    touch nina-icon.png
    
    # Create packages based on distribution
    if [ -f /etc/os-release ]; then
        . /etc/os-release
        if [[ $NAME == *"Ubuntu"* ]] || [[ $NAME == *"Debian"* ]]; then
            create_deb
        fi
    fi
    
    # Always create AppImage and tarball
    create_appimage
    create_tarball
    
    echo -e "${GREEN}=== Packaging completed ===${NC}"
    echo -e "${YELLOW}Packages created in:${NC} $PACKAGE_DIR"
}

# Run main function
main "$@"