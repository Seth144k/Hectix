#!/bin/bash

TARGET="linux-64"

if [[ "$1" == "windows64" ]]; then
    TARGET="win-x64"
elif [[ "$1" == "windows32" ]]; then
    TARGET="win-x86"
elif [[ "$1" == "windows-arm64" ]]; then
    TARGET="win-arm64"

elif [[ "$1" == "linux64" ]]; then
    TARGET="linux-x64"
elif [[ "$1" == "linux-arm64" ]]; then
    TARGET="linux-arm64"
elif [[ "$1" == "linux-arm32" ]]; then
    TARGET="linux-arm"

else
    echo "Incorrect Platform Specified"
    exit 1
fi

cd Hectix_App || exit 1
# publishes to Hectix_App/bin/Release/net9.0/publish
dotnet restore
dotnet publish -c Release -r $TARGET --self-contained true /p:PublishSingleFile=true /p:IncludeNativeLibrariesForSelfExtract=true