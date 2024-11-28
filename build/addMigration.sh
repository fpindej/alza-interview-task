#!/bin/bash

# Parameters
MigrationName=$1
ProjectPath="../src/Alza.Persistence/Alza.Persistence.csproj"
StartupProjectPath="../src/Alza.Api/Alza.Api.csproj"

# Function to execute commands
execute_command() {
    local command=$1

    echo "Executing: $command"
    $command
    if [ $? -ne 0 ]; then
        echo "Error: Command exited with code $?"
        exit $?
    fi
}

# Check if MigrationName is provided
if [ -z "$MigrationName" ]; then
    echo "Migration name must be provided"
    exit 1
fi

echo "Starting migration: $MigrationName"

# Run migration command
execute_command "dotnet ef migrations add $MigrationName --project $ProjectPath --startup-project $StartupProjectPath"

echo "Migration $MigrationName added successfully."
echo "Running the project with localDev environment setup should apply the migrations automatically."
