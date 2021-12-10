# Goes to the solution catalog
cd C:\C#_Projects\EPAM\M01\M01_ConsoleApp

# Perform the Build
dotnet build -c Release -o win10-x64

# Publish the project
dotnet publish -c release -r win10-x64 --self-contained