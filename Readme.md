# Hectix Engine

## What Is Hectix Engine?
Hectix Engine will be a fully featured 2D game engine written entirely in C# 9.0 by Seth Israel using Silk.NET for graphics and rendering. Hectix Engine uses Lua as the scripting language, allowing a fast, easy, and powerful way to create games on your own.

## How To Run
Hectix Engine requires both the Dotnet SDK and the Dotnet Runtime version 9.0 or above to work. Download the source or clone, and open the Hectix.sln in something like Visual Studio, or Visual Studio Code (VSCode). Hectix Engine hasn't been tested with any other IDE, but there is likely a similar process. If you are using VSCode you would simply cd into the Hectix_App directory, and enter ```dotnet run```. Be aware that Hectix is developed using VSCode as the IDE so possibly some features of intelliSense, code snippets, and debugging, may not work as well on others.

```
cd Hectix_App
dotnet run
```

## Deployment
When you finish making the changes you want to Hectix Engine, you can run the provided build.sh (or build.bat) script in the root project folder for quick and easy cross platform deployment. After it's done generating the files, the binaries can be found in: ```Hectix_App/bin/Release/net9.0/publish```. From there, it can be compressed and distributed accordingly.

## Build.sh Commands
* ```./build.sh windows64```
* ```./build.sh windows32```
* ```./build.sh windows-arm64```
* ```./build.sh linux64```
* ```./build.sh linux-arm64```
* ```./build.sh linux-arm32```

## Build.bat Commands
* ```.\build.bat windows64```
* ```.\build.bat windows32```
* ```.\build.bat windows-arm64```
* ```.\build.bat linux64```
* ```.\build.bat linux-arm64```
* ```.\build.bat linux-arm32```

## Notes for MacOS
Hectix Engine is currently supported on Windows and Linux only, due to Apple's limited support for modern OpenGL.

## License

Hectix Engine is licensed under the [GNU General Public License v3.0](LICENSE).

This project uses [Silk.NET](https://github.com/dotnet/Silk.NET), which is MIT-licensed.  
Please see [`THIRD_PARTY_NOTICES.md`](THIRD_PARTY_NOTICES.md) for full third-party license information.
