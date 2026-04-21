cmake_minimum_required(VERSION 3.18)
project(NINA_IndiBridge LANGUAGES CXX)

# Set C++ standard
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

# Find required packages
find_package(PkgConfig REQUIRED)
pkg_check_modules(INDI REQUIRED indi)
pkg_check_modules(LIBNOVA REQUIRED libnova)
pkg_check_modules(CFITSIO REQUIRED cfitsio)
pkg_check_modules(LIBUSB REQUIRED libusb-1.0)

# Compiler flags
set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -Wall -Wextra -pedantic")

# Source files
set(SOURCES
    src/IndiClient.cpp
    src/IndiDeviceManager.cpp
    src/IndiPropertyHandler.cpp
)

# Header files
set(HEADERS
    include/IndiClient.h
    include/IndiDeviceManager.h
    include/IndiPropertyHandler.h
    include/IndiException.h
)

# Create library
add_library(indibridge STATIC ${SOURCES} ${HEADERS})

# Set include directories
target_include_directories(indibridge PUBLIC
    include
    ${INDI_INCLUDE_DIRS}
    ${LIBNOVA_INCLUDE_DIRS}
    ${CFITSIO_INCLUDE_DIRS}
    ${LIBUSB_INCLUDE_DIRS}
)

# Link libraries
target_link_libraries(indibridge
    ${INDI_LIBRARIES}
    ${LIBNOVA_LIBRARIES}
    ${CFITSIO_LIBRARIES}
    ${LIBUSB_LIBRARIES}
)

# Installation
install(TARGETS indibridge
    LIBRARY DESTINATION lib
    ARCHIVE DESTINATION lib
    RUNTIME DESTINATION bin
)

install(FILES ${HEADERS}
    DESTINATION include/nina-indi
)