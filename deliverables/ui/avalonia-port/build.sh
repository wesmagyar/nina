#!/bin/bash

# Build script for NINA Avalonia Port
# This script builds the Avalonia port of NINA

set -e  # Exit on any error

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

echo -e "${GREEN}=== NINA Avalonia Port Build Script ===${NC}"

# Navigate to the Avalonia project directory
cd /home/wes/nina-fork/deliverables/ui/avalonia-port/NINA.Avalonia

# Check if dotnet is installed
if ! command -v dotnet &> /dev/null; then
    echo -e "${RED}Error: .NET is not installed${NC}"
    exit 1
fi

# Restore NuGet packages
echo -e "${YELLOW}Restoring NuGet packages...${NC}"
dotnet restore

# Build the application
echo -e "${YELLOW}Building the application...${NC}"
dotnet build --configuration Release

echo -e "${GREEN}Build completed successfully!${NC}"