# Goes to the solution catalog
cd C:\C#_Projects\EPAM\M01\M01_ConsoleApp

# Perform the Build
dotnet build -c Release -o win10-x64

# Publish the project to work on Windows 10 x64
dotnet publish -c release -r win10-x64 --self-contained

# Public the project to work on Ubuntu 20.04-x64
dotnet publish -c Release -r ubuntu.20.04-x64 --self-contained