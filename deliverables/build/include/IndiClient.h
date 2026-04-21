#ifndef INDICLIENT_H
#define INDICLIENT_H

#include <indiclient.h>
#include <indidevapi.h>
#include <indibase.h>
#include <iostream>
#include <string>
#include <map>
#include <vector>
#include <memory>

class IndiClient : public INDI::BaseClient {
public:
    IndiClient(const std::string& host, unsigned int port);
    virtual ~IndiClient();

    // Connection methods
    bool connect();
    bool disconnect();
    bool isConnected() const;

    // Device management
    std::vector<std::string> getDevices() const;
    bool connectDevice(const std::string& deviceName);
    bool disconnectDevice(const std::string& deviceName);

    // Property access
    std::map<std::string, IPerm> getProperties(const std::string& deviceName) const;
    IPState getPropertyState(const std::string& deviceName, const std::string& propertyName) const;

private:
    // INDI client callbacks
    void newDevice(INDI::BaseDevice dp) override;
    void removeDevice(INDI::BaseDevice dp) override;
    void newProperty(INDI::Property property) override;
    void removeProperty(INDI::Property property) override;
    void newBLOB(IBLOB* bp) override;
    void newSwitch(ISwitchVectorProperty* svp) override;
    void newNumber(INumberVectorProperty* nvp) override;
    void newText(ITextVectorProperty* tvp) override;
    void newLight(ILightVectorProperty* lvp) override;
    void newMessage(INDI::BaseDevice dp, int messageID) override;
    void serverConnected() override;
    void serverDisconnected(int exit_code) override;

    std::string m_host;
    unsigned int m_port;
    bool m_connected;
};

#endif // INDICLIENT_H