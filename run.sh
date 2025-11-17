#!/bin/bash

echo "Starting Jaemy Ho Portfolio Website..."
echo

# Check if .NET SDK is installed
if ! command -v dotnet &> /dev/null; then
    echo "Error: .NET SDK is not installed or not in PATH"
    echo "Please install .NET 8.0 SDK from https://dotnet.microsoft.com/download"
    exit 1
fi

# Check if MySQL is running (optional check)
echo "Checking system requirements..."

# Restore NuGet packages
echo "Restoring NuGet packages..."
dotnet restore
if [ $? -ne 0 ]; then
    echo "Error: Failed to restore packages"
    exit 1
fi

# Update database
echo "Updating database..."
dotnet ef database update
if [ $? -ne 0 ]; then
    echo "Warning: Database update failed. Make sure MySQL is running and connection string is correct."
    echo "Continuing without database update..."
fi

# Run the application
echo "Starting the application..."
echo "Open your browser to https://localhost:5001 or http://localhost:5000"
echo "Press Ctrl+C to stop the application"
echo
dotnet run
