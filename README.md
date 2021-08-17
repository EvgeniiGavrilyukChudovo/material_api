# material_api

- Install net core 3.1
- Download docker.
- Run scripts/run-ravendb-linux.ps1 to install ravenDb emulator and run it inside docker container. By default it use such location 'http://localhost:8080/'
- Inside RavenDb create database with name 'Material'.
If you want to have different name or address, changed it in docker and go to appsettings.json in 'Material.Hosting' project and change here too.

- Open and run 'Material.Hosting' project.
- Navigate to the link in your browser: http://localhost:5000/swagger/index.html

Now you can all check CRUD operations via swagger interface.



