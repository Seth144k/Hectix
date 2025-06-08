param (
    [string]$Platform
)

$TARGET = "linux-x64"

switch ($Platform) {
    "windows64"      { $TARGET = "win-x64" }
    "windows32"      { $TARGET = "win-x86" }
    "windows-arm64"  { $TARGET = "win-arm64" }

    "linux64"        { $TARGET = "linux-x64" }
    "linux-arm64"    { $TARGET = "linux-arm64" }
    "linux-arm32"    { $TARGET = "linux-arm" }

    default {
        Write-Host "Incorrect Platform Specified"
        exit 1
    }
}

if (-not (Test-Path "Hectix_App")) {
    Write-Host "Hectix_App directory not found"
    exit 1
}

Set-Location "Hectix_App"

dotnet restore
dotnet publish -c Release -r $TARGET --self-contained `
    /p:PublishSingleFile=false `
    /p:IncludeNativeLibrariesForSelfExtract=true