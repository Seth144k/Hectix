# Hectix Engine

## WHAT IS HECTIX ENGINE?
Hectix Engine is a fully featured 2D game engine written entirely in C# by Seth Israel with Silk.NET for graphics, and using VSCode as my IDE of choice. Hectix Engine uses Lua as the scripting language, allowing a fast, easy, and powerful way to create games on your own.

## HOW TO RUN
Download the source or clone, and open the Hectix.sln in something like Visual Studio, or Visual Studio Code (VSCode). I haven't tested it with Mono Develop, but I assume there is a similar process. If your using VSCode you would simply cd into the Hectix_App directory, and enter ```dotnet run```. I personally have not used any other IDE for development because my hardware is quite outdated, but I once again assume there is a similar process to running. But once again be aware, Hectix Engine is developed using VSCode as the IDE so possibly some features of intellisense and code snippets and debugging or something may not work as well on others.

```
cd Hectix_App
dotnet run
```

## DEPLOYMENT
When you finish making the changes you want to Hectix Engine, you can run the provided build.sh script in the root project folder for quick and easy cross platform deployment. After it's done generating the files, the binaries can be found in: Hectix_App/bin/Release/net9.0/publish. From there, it can be zipped up and distributed accordingly.

## LIST OF DEPLOYMENT PLATFORM COMMANDS
```./build.sh windows64```
```./build.sh windows32```
```./build.sh windows-arm64```
```./build.sh linux64```
```./build.sh linux-arm64```
```./build.sh linux-arm32```
```./build.sh mac64```
```./build.sh mac-arm64```