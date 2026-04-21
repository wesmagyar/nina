# INDI Alpaca Bridge Setup for NINA

## Overview

This document describes how to set up the INDI Alpaca bridge to allow NINA to control INDI devices through the ASCOM Alpaca protocol.

## Components

1. **INDI Server** - Runs INDI drivers for hardware devices
2. **indi_alpaca_server** - Exposes INDI devices as ASCOM Alpaca devices
3. **NINA** - Astronomy imaging software that can connect to ASCOM Alpaca devices

## Setup Process

### 1. Install and Configure INDI Server

First, you need to set up an INDI server with your hardware drivers:

```bash
# Install INDI server and drivers (example for ZWO cameras)
sudo apt-get install indi-bin indi-zwo

# Start INDI server with ZWO driver
indiserver -v indi_zwo_ccd

# Or start with multiple drivers
indiserver -v indi_zwo_ccd indi_eqmod_telescope
```

### 2. Configure indi_alpaca_server

The indi_alpaca_server acts as a bridge between INDI and ASCOM Alpaca:

1. Load the indi_alpaca_server driver in your INDI server
2. Configure the following settings in the indi_alpaca_server:
   - **INDI Server Settings**: Set host and port to connect to your INDI server
   - **Server Settings**: Set the host and port for the Alpaca server to listen on
   - **Discovery Settings**: Set the discovery port (default 32227)
   - **Startup Delay**: Set delay before connecting to INDI server

3. Start the Alpaca server through the INDI control panel

### 3. Configure NINA to Discover Alpaca Devices

Once the indi_alpaca_server is running:

1. Open NINA
2. Go to Equipment > Camera > Alpaca Direct IP
3. NINA should automatically discover Alpaca devices via network discovery
4. Alternatively, manually configure the IP address and device number for static connections

### 4. Test Connection

1. Try connecting to your INDI camera through the Alpaca bridge
2. Attempt to take a simple exposure to verify functionality
3. Test other devices (mount, focuser, filter wheel) as needed

## Device Mapping

The indi_alpaca_server maps INDI devices to ASCOM Alpaca devices as follows:

- **INDI CCD drivers** → Alpaca Camera devices
- **INDI Telescope drivers** → Alpaca Telescope devices
- **INDI Focuser drivers** → Alpaca Focuser devices
- **INDI Filter Wheel drivers** → Alpaca Filter Wheel devices
- **INDI Dome drivers** → Alpaca Dome devices

## Troubleshooting

### Common Issues

1. **Discovery not working**: 
   - Ensure firewall isn't blocking discovery port (default 32227)
   - Check that both NINA and indi_alpaca_server are on the same network

2. **Connection refused**:
   - Verify INDI server is running and accessible
   - Check host/port settings in indi_alpaca_server configuration

3. **Device not responding**:
   - Ensure the corresponding INDI driver is properly configured and connected
   - Check INDI driver logs for error messages

### Log Files

- INDI server logs: Check console output or syslog
- NINA logs: Located in NINA installation directory or user profile folder

## Testing with Simulated Hardware

For initial testing without physical hardware:

1. Install INDI simulator drivers:
   ```bash
   sudo apt-get install indi-bin indi-driver
   ```

2. Start INDI server with simulator drivers:
   ```bash
   indiserver -v indi_simulator_ccd indi_simulator_telescope
   ```

3. Configure and start indi_alpaca_server as described above

4. Connect through NINA and test basic functionality