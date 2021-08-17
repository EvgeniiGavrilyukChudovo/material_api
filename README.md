# material_api

- Install net core 3.1
- Download and install docker.
- Run powershell script from 'scripts/run-ravendb-linux.ps1' to install ravenDb emulator. By default it is is located here 'http://localhost:8080/'
- Inside RavenDb create database with name 'Material'.
If you want use different database name you can change it in appsettings.json in 'Material.Hosting' project.

- Open and run 'Material.Hosting' project.
- Navigate to the link in your browser: http://localhost:5000/swagger/index.html

Now you can check all CRUD operations via swagger interface.



