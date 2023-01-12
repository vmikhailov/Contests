cmake_minimum_required(VERSION 3.23)
project(Cpp)

set(CMAKE_CXX_STANDARD 20)
set(BOOST_ROOT C:/Work/SDK/boost_1_80_0)
find_package(Boost 1.80.0)

if(Boost_FOUND)
    message(STATUS "Boost_INCLUDE_DIRS: ${Boost_INCLUDE_DIRS}")
    message(STATUS "Boost_LIBRARIES: ${Boost_LIBRARIES}")
    message(STATUS "Boost_VERSION: ${Boost_VERSION}")

    include_directories(${Boost_INCLUDE_DIRS})
else()
    message(FATAL_ERROR "Could not find boost!")
endif()



add_executable(Cpp main.cpp SummaryRangesTask.h RotateImage.h PascalTriangle.h SerializeDeserializeBinSearchTree.h Shift2DGrid.h MatrixHelpers.h IsSubsequence.h SetMatrixZeros.h DeciBinaryPartTask.h StrictlyPalindromicNumberTask.h PrimesTest.h PerfBinTree.h)
