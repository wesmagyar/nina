# EQ-1: INDI Alpaca Integration Guide

## Overview
This document provides technical guidance for integrating INDI hardware through the Alpaca protocol with NINA's existing Alpaca support.

## Key Concept
NINA already has robust Alpaca support built-in. The INDI `indi_alpaca_server` bridges INDI drivers to appear as Alpaca devices, which NINA can then consume through its existing AlpacaDirectCamera, AlpacaDirectTelescope, etc. implementations.

## Architecture Flow

```
NINA Equipment Layer
│
├── AlpacaDirectCamera/Telescope/etc.
│   └── Communicates via HTTP/REST to Alpaca devices
│
INDI Alpaca Server Bridge
│
├── Exposes INDI drivers as Alpaca devices
│   └── Automatic capability parsing and interface generation
│
Actual INDI Drivers
├── ZWO ASI Camera Drivers
├── QHY CCD Drivers
├── Celestron/SkyWatcher Mount Drivers
└── Other hardware drivers
```

## Configuration Requirements

### indi_alpaca_server Settings
1. **Alpaca Server Host/Port**: Where Alpaca clients connect (e.g., 0.0.0.0:11111)
2. **INDI Server Host/Port**: Where INDI drivers are running (e.g., localhost:7624)
3. **Discovery Port**: UDP port for Alpaca discovery (default 32227)
4. **Connection Settings**: Timeout, retries, retry delay
5. **Startup Delay**: Time to wait for INDI server readiness

### NINA Alpaca Settings
Located in `AlpacaDirectSettings.cs`:
1. **ServiceType**: Http or Https
2. **IpAddress**: IP of Alpaca server (usually localhost if running locally)
3. **Port**: Port where indi_alpaca_server listens
4. **DeviceNumber**: Device index for multi-device setups

## Implementation Steps

### Step 1: Set Up INDI Environment
1. Install INDI server and drivers for target hardware
2. Configure and test native INDI drivers independently
3. Ensure drivers are accessible via INDI server

### Step 2: Configure indi_alpaca_server
1. Start `indi_alpaca_server` driver
2. Set INDI Server Host/Port to point to running INDI server
3. Configure Alpaca Server Host/Port for client connections
4. Test that INDI drivers appear as Alpaca devices using Alpaca dashboard or discovery

### Step 3: Configure NINA Alpaca Settings
1. In NINA, select Alpaca Camera/Telescope/etc.
2. Enter IP address and port where `indi_alpaca_server` is listening
3. Set appropriate device number
4. Test connection through NINA's device interface

## Current Device Support Status

### Fully Supported (by INDI Alpaca Server)
- Mounts/Telescopes
- Cameras

### Partial Support (needs investigation)
- Focusers
- Filter Wheels
- Domes
- Switches
- Safety Monitors

## Testing Procedure

### Basic Connectivity Test
1. Start INDI server with target drivers
2. Start `indi_alpaca_server` and configure connection to INDI server
3. Use Alpaca management API to list available devices
4. Verify target devices appear in the list

### Device Functionality Test
1. Configure NINA Alpaca device with correct IP/port
2. Connect through NINA equipment interface
3. Verify device properties are correctly reported
4. Test basic operations (movement for mounts, exposures for cameras)

## Troubleshooting Common Issues

### Device Not Appearing
1. Check that `indi_alpaca_server` is properly connected to INDI server
2. Verify INDI drivers are loaded and functioning
3. Check firewall settings for ports in use
4. Confirm discovery port is not blocked

### Connection Refused
1. Verify `indi_alpaca_server` is running and listening
2. Check IP address and port configuration in NINA
3. Ensure network connectivity between NINA and `indi_alpaca_server`

### Properties Not Updating
1. Check polling intervals in NINA equipment settings
2. Verify INDI driver is properly reporting changes
3. Monitor network traffic for communication issues

## Future Enhancements

### Additional Device Support
Work with INDI team to extend device type support in `indi_alpaca_server`:
- Guider interfaces
- Rotator devices
- Weather stations

### Performance Optimizations
- Connection pooling for multiple devices
- Caching strategies for frequently accessed properties
- Batch operations for reduced network overhead

## Integration Checklist

- [ ] INDI server and drivers installed and tested
- [ ] `indi_alpaca_server` configured and running
- [ ] Alpaca device discovery working
- [ ] NINA Alpaca settings configured
- [ ] Basic device connectivity verified
- [ ] Core functionality tested
- [ ] Error handling and edge cases validated

## References

1. INDI Repository: https://github.com/indilib/indi
2. ASCOM Alpaca Specification: https://www.ascom-alpaca.org/
3. NINA Equipment Layer Implementation
4. INDI Alpaca Server Source Code: drivers/alpaca/indi_alpaca_server.cpp

---
Document Version: 1.0
Created: 2026-04-21
Author: CTO