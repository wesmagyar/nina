# NINA Linux Build Environment
# This Dockerfile creates a containerized build environment for NINA on Linux

FROM ubuntu:22.04

# Set environment variables
ENV DEBIAN_FRONTEND=noninteractive
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1

# Install build dependencies
RUN apt-get update && apt-get upgrade -y && \
    apt-get install -y \
        # Build tools
        build-essential \
        cmake \
        pkg-config \
        ninja-build \
        # .NET SDK
        wget \
        # INDI and astronomy libraries
        libindi-dev \
        libnova-dev \
        libcfitsio-dev \
        libusb-1.0-0-dev \
        # GUI libraries for Avalonia
        libgtk-3-dev \
        librsvg2-dev \
        libxt-dev \
        libx11-dev \
        libgl1-mesa-dev \
        libgl-dev \
        libpulse-dev \
        # Packaging tools
        zip \
        unzip \
        debhelper \
        # Git for version control
        git \
        # Additional utilities
        curl \
        jq \
        && \
    # Clean up
    apt-get clean && \
    rm -rf /var/lib/apt/lists/*

# Install .NET SDK
RUN wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh && \
    chmod +x dotnet-install.sh && \
    ./dotnet-install.sh --channel 8.0 --install-dir /usr/share/dotnet && \
    ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet

# Set working directory
WORKDIR /app

# Copy build scripts
COPY scripts/ ./scripts/
COPY packaging/ ./packaging/
COPY cmake/ ./cmake/

# Make scripts executable
RUN chmod +x ./scripts/*.sh ./packaging/*.sh

# Default command
CMD ["/bin/bash"]