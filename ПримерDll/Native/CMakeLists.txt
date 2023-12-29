cmake_minimum_required (VERSION 2.8.12)
project (Native)
set(CMAKE_MACOSX_RPATH 1)
set(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

add_library(Native SHARED
    SampleFunctions.cpp
)

install(TARGETS Native)

