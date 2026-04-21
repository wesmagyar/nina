#!/bin/bash

# Simple build script for NINA.Avalonia project only
# This script builds just the main Avalonia project without dependencies

set -e  # Exit on any error

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
NC='\033[0m' # No Color

echo -e "${GREEN}=== NINA.Avalonia ImageWindow Build Script ===${NC}"

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

# Build only the main project (skip dependent projects)
echo -e "${YELLOW}Building the main project...${NC}"
dotnet build --configuration Release --no-dependencies

echo -e "${GREEN}Build completed successfully!${NC}"
echo -e "${YELLOW}Note: This build focused only on the main NINA.Avalonia project${NC}"
echo -e "${YELLOW}to validate the ImageWindow implementation.${NC}"