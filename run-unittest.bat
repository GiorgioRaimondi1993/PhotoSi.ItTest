@echo off
REM Script to run all unit tests in a .NET solution

REM Set the path to the solution or test projects
set SOLUTION_PATH=./PhotoSi.ItTest.MarketPlace.sln

REM Navigate to the solution folder
cd %SOLUTION_PATH%

REM Clean previous builds
echo Cleaning the solution...
dotnet clean PhotoSi.ItTest.MarketPlace.sln

REM Build the solution
echo Building the solution...
dotnet build  PhotoSi.ItTest.MarketPlace.sln --configuration Release

REM Run tests for all test projects in the solution
echo Running tests...
dotnet test PhotoSi.ItTest.MarketPlace.sln --verbosity normal

REM Check if the tests passed
IF %ERRORLEVEL% EQU 0 (
    echo All tests passed successfully!
    exit /b 0
) ELSE (
    echo Some tests failed. Check the output above for details.
    exit /b 1
)
