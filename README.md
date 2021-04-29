# AspNetCore Angular Single Page Application with Dynamic Forms

# Prerequisites You will need the following tools:
1.	Visual Studio Code or Visual Studio 2019 Preview
2.	.NET Core SDK 3.1
3.	Node.js (version 10 or later) with npm (version 6.9.0 or later)

# Running the application
•	Unzip project files
•	There are two projects – Frontend and Backend
•	Open command prompt on the project root directory.
•	Build the application (will also restore the npm packages)
“dotnet build”

•	Run the application
“dotnet run”

# This application consists of:
1.	Angular spa frontend project developed using Angular 8 and TypeScript
2.	RESTful API Backend project using ASP.NET Core 3.1 MVC Web API
3.	JSON file as data source
4.	Frontend contains two View Components – Summary and Details
5.	Summary View is basic angular table binding – Data Fetch from Get API
6.	Details View is a dynamic form – Data for fields is dynamic fetch from API

# Installing from Installer.bat
•	Place the Installer.bat file in Frontend Project where bin folder is present.
•	Edit the file and replace the text "{your project folder path here}" with the project folder location on your local machine.
•	After saving the file, double click the Installer.bat file
•	The application will now start at localhost .
•	Access the application from browser at http://localhost:41578/ or the port no available on your localhost.

# Installation Notes: 
1.	You should have the latest version of Node.js, which is supported by Angular CLI 8.0+ 
2.	When running the project please wait for all dependencies to be restored; "dotnet restore" for asp.net api project & "npm install" for angular project. 
3.	When using Visual Studio this is automatic, check the output window or status bar to know that the package/dependencies restore process is complete before launching your program for the first time. If you get any errors, consider running manually the steps to build the project and note where the errors occur. 
4.	Open command prompt and do the below steps: run 'dotnet restore' from the two project folders - Restore nuget packages run 'npm install' from the project with package.json
5.	Restore npm packages Try running the application again - Test to make sure it all works When running the client(angular) project on a different address/domain from the backend, configure the base URL of the client to match that of the server. 
