# CMakeList.txt : CMake project for CMakeProject1, include source and define
# project specific logic here.
#

cmake_minimum_required (VERSION 3.8)

project ("libCecCoreNative")

find_path(CEC_LIB NAME "include" PATHS "../libcec-build/amd64")

# Add source to this project's executable.
add_library (libCecCoreNative SHARED
"libCecCoreNative.cpp"
"stdafx.cpp"
)

target_include_directories(libCecCoreNative PRIVATE ${CEC_LIB})
target_link_directories(libCecCoreNative PRIVATE ${CEC_LIB})
target_link_libraries(libCecCoreNative cec)

if (CMAKE_VERSION VERSION_GREATER 3.12)
  set_property(TARGET libCecCoreNative PROPERTY CXX_STANDARD 20)
endif()

# TODO: Add tests and install targets if needed.


