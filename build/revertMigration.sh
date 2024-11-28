#!/bin/bash

ProjectPath="../src/Alza.Persistence/Alza.Persistence.csproj"
StartupProjectPath="../src/Alza.Api/Alza.Api.csproj"

execute_command() {
    command=$1
    echo "Executing: $command"
    eval $command
    status=$?
    if [ $status -ne 0 ]; then
        echo "Error: Command exited with code $status"
        exit $status
    fi
}

echo "Reverting the last migration..."

execute_command "dotnet ef migrations remove --project $ProjectPath --startup-project $StartupProjectPath"

echo "Last migration successfully reverted."