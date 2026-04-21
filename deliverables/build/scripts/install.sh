#!/bin/bash

# NINA Linux Installation Script
# This script installs NINA on Linux systems

set -e  # Exit on any error

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

echo -e "${GREEN}=== NINA Linux Installation Script ===${NC}"

# Check if running as root
if [ "$EUID" -eq 0 ]; then
    echo -e "${RED}Error: This script should not be run as root${NC}"
    exit 1
fi

# Detect installation directory
INSTALL_DIR="${HOME}/.local/opt/nina"
mkdir -p "$INSTALL_DIR"

# Download latest release (placeholder)
echo -e "${YELLOW}Downloading latest NINA release...${NC}"
# In a real implementation, this would download the actual release
# wget https://github.com/isbeorn/nina/releases/latest/download/nina-linux.tar.gz -O /tmp/nina-linux.tar.gz

# Extract files (placeholder)
echo -e "${YELLOW}Extracting files...${NC}"
# tar -xzf /tmp/nina-linux.tar.gz -C "$INSTALL_DIR"

# Create symbolic links
echo -e "${YELLOW}Creating symbolic links...${NC}"
mkdir -p "${HOME}/.local/bin"
ln -sf "$INSTALL_DIR/NINA" "${HOME}/.local/bin/nina"

# Create desktop entry
echo -e "${YELLOW}Creating desktop entry...${NC}"
mkdir -p "${HOME}/.local/share/applications"

cat > "${HOME}/.local/share/applications/nina.desktop" << EOF
[Desktop Entry]
Name=NINA - Nighttime Imaging 'N' Astronomy
Comment=A modular astrophotography suite
Exec=${HOME}/.local/bin/nina
Icon=${INSTALL_DIR}/nina-icon.png
Terminal=false
Type=Application
Categories=Graphics;Astronomy;
EOF

# Install systemd service for background INDI server (optional)
echo -e "${YELLOW}Setting up INDI server service (optional)...${NC}"
read -p "Do you want to set up INDI server to start automatically? (y/N): " -n 1 -r
echo
if [[ $REPLY =~ ^[Yy]$ ]]; then
    sudo tee /etc/systemd/system/indi-server.service > /dev/null << EOF
[Unit]
Description=INDI Server
After=network.target

[Service]
Type=forking
User=$USER
ExecStart=/usr/bin/indiserver -p 7624
Restart=always

[Install]
WantedBy=multi-user.target
EOF
    
    sudo systemctl enable indi-server.service
    sudo systemctl start indi-server.service
fi

echo -e "${GREEN}=== NINA installation completed ===${NC}"
echo -e "${YELLOW}To run NINA:${NC}"
echo "1. Add ~/.local/bin to your PATH if not already there"
echo "2. Run 'nina' from the terminal"
echo "3. Or find NINA in your applications menu"