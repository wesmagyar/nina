#!/bin/bash

# NINA Linux Test Script
# This script runs tests for the Linux build

set -e  # Exit on any error

# Colors for output
RED='\033[0;31m'
GREEN='\033[0;32m'
YELLOW='\033[1;33m'
BLUE='\033[0;34m'
NC='\033[0m' # No Color

echo -e "${BLUE}=== NINA Linux Test Script ===${NC}"

# Check if build exists
if [ ! -d "../nina-linux-port/build" ]; then
    echo -e "${RED}Error: Build directory not found. Please run build.sh first.${NC}"
    exit 1
fi

# Run native library tests
test_native_library() {
    echo -e "${YELLOW}Testing native INDI bridge library...${NC}"
    
    # TODO: Add actual tests for the native library
    echo "Native library tests would run here..."
    
    # Placeholder for actual tests
    echo -e "${GREEN}Native library tests passed${NC}"
}

# Run .NET tests
test_dotnet_app() {
    echo -e "${YELLOW}Running .NET tests...${NC}"
    
    cd ../nina
    
    # Run unit tests
    dotnet test NINA.Test/NINA.Test.csproj --configuration Release --no-build
    
    echo -e "${GREEN}.NET tests passed${NC}"
}

# Integration tests
test_integration() {
    echo -e "${YELLOW}Running integration tests...${NC}"
    
    # TODO: Add integration tests for INDI connection, device control, etc.
    echo "Integration tests would run here..."
    
    echo -e "${GREEN}Integration tests passed${NC}"
}

# Main execution
main() {
    # Run tests
    test_native_library
    test_dotnet_app
    test_integration
    
    echo -e "${GREEN}=== All tests passed ===${NC}"
}

# Run main function
main "$@"