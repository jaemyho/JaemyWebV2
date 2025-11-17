@echo off
echo Starting Jaemy Ho Portfolio Website...
echo.

REM Check if .NET SDK is installed
dotnet --version >nul 2>&1
if %errorlevel% neq 0 (
    echo Error: .NET SDK is not installed or not in PATH
    echo Please install .NET 8.0 SDK from https://dotnet.microsoft.com/download
    pause
    exit /b 1
)

REM Check if MySQL is running (optional check)
echo Checking system requirements...

REM Restore NuGet packages
echo Restoring NuGet packages...
dotnet restore
if %errorlevel% neq 0 (
    echo Error: Failed to restore packages
    pause
    exit /b 1
)

REM Update database
echo Updating database...
dotnet ef database update
if %errorlevel% neq 0 (
    echo Warning: Database update failed. Make sure MySQL is running and connection string is correct.
    echo Continuing without database update...
)

REM Run the application
echo Starting the application...
echo Open your browser to https://localhost:5001 or http://localhost:5000
echo Press Ctrl+C to stop the application
echo.
dotnet run

pause
