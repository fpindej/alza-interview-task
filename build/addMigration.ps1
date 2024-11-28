param(
    [string]$MigrationName,
    [string]$ProjectPath = "..\src\Alza.Persistence\Alza.Persistence.csproj",
    [string]$StartupProjectPath = "..\src\Alza.Api\Alza.Api.csproj"
)

function ExecuteCommand {
    param(
        [string]$Command
    )

    try {
        Write-Host "Executing: $Command"
        Invoke-Expression $Command
        if ($LASTEXITCODE -ne 0) {
            throw "Command exited with code $LASTEXITCODE"
        }
    } catch {
        Write-Host "Error: $_"
        exit $LASTEXITCODE
    }
}

if (-not $MigrationName) {
    Write-Host "Migration name must be provided"
    exit
}

Write-Host "Starting migration: $MigrationName"

ExecuteCommand "dotnet ef migrations add $MigrationName --project $ProjectPath --startup-project $StartupProjectPath"

Write-Host "Migration $MigrationName added successfully."
Write-Host "Running the project with localDev environment setup should apply the migrations automatically."