#ifndef INDIEXCEPTION_H
#define INDIEXCEPTION_H

#include <stdexcept>
#include <string>

class IndiException : public std::runtime_error {
public:
    explicit IndiException(const std::string& message)
        : std::runtime_error(message) {}
};

#endif // INDIEXCEPTION_H