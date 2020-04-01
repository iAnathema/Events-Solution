---------------------------------
Prerequisite
---------------------------------

[Visual Studio 2017]

[Node] - https://nodejs.org/en/download/ 
Verify that you are running at least Node.js version 8.x or greater and npm version 5.x or greater by running node -v and npm -v in a terminal/console window. Older versions produce errors, but newer versions are fine.

[Angular Cli 7] - To install run the following in command line. 
npm install -g @angular/cli
verify version running: ng --version

[Typescript] - https://www.typescriptlang.org/
Verify that you have version 3.1 or above for npm global and SDK for visual studio. 
To check Global: You can check by running tsc -v in any terminal window.
To check Visual Studio 2017: Right click on project -> properties -> Typescript Build -> Typescript Version 3.1 (should be there)


--------------------------------------
Getting Started
--------------------------------------

1. Right click on solution and select "Restore Nuget Packages"
2. Open terminal windows and browse to project location where the package.json file is, then run the following to install all the npm packages:
"npm install"
3. Run the application

---------------------------------
Swagger
---------------------------------
To test swagger

1. Run applicaton
2. add "/swagger" to url, should take you to swagger api tester

---------------------------------
Angular Karma Testing
---------------------------------
To test angular using karma
1. run "ng test" in a terminal where the angular.json file is located

---------------------------------
Config environment.ts on Developing
--------------------------------
export const environment = {
    production: false,
    apiUrl: 'http://localhost:{iisDevPort}/api'
};

---------------------------------
Config API URL config.js on Production
--------------------------------
1. Create a config.js, put in wwwroot folder
2. Modify and write "window['apiUrl'] = 'http://urladrress:port/api'" to set the Api source URL

---------------------------------
Publish Commands
---------------------------------
1. dotnet publish -c Release -r win-x64 ---------- x Windows
2. dotnet publish -c Release -r linux-x64 -------- x Linux

---------------------------------
Self-Package Command
---------------------------------
1 .\warp-packer.exe --arch windows-x64 --input_dir .\bin\Release\netcoreapp2.2\win-x64\publish --exec EventsPortal.exe --output bin\win-x64\EventsPortal.exe
2 .\warp-packer.exe --arch linux-x64 --input_dir .\bin\Release\netcoreapp2.2\linux-x64\publish --exec EventsPortal --output bin\linux-x64\EventsPortal
