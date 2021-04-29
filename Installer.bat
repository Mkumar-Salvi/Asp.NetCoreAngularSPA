SET ASPNETCORE_ENVIRONMENT=Development
SET LAUNCHER_PATH=bin\Debug\netcoreapp3.1\FrontEnd_Project_Angular.exe
cd /d "C:\Program Files\IIS Express\"

iisexpress.exe /config:"{your project folder path here}\.vs\CoreAPI_Angular\config\applicationhost.config" /site:"FrontEnd_Project_Angular" /apppool:"FrontEnd_Project_Angular AppPool

iisexpress.exe /config:"{your project folder path here}\.vs\CoreAPI_Angular\config\applicationhost.config" /site:"Backend_Project_Api" /apppool:"Backend_Project_Api AppPool