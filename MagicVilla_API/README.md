# Proyecto base Net CORE 7


Para instalar los paquetes necesarios 
``
nuget install packages.config
``

Para hacer debuggin mientras se esta ejecutando la aplicacion
``
dotnet watch -lp https
``

Para iniciar con https 
``
dotnet run --launch-profile https
``

Para realizar migraciones 
``
Scaffold-DbContext "Data Source=192.168.2.217;Initial Catalog=ControlMateriales;User ID=user;Password=pass;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
``
# Cheat Sheet Entity framework
## Desde el CLI de netcore
```
dotnet ef database drop -f -v   --Borrar la base de datos
dotnet ef migrations add Initial  --Agregar snapshot en migrations
dotnet ef database update     --Actualizar la base de datos
```


## Desde el Package Manager Console en Visual Studio
```

Drop-Database -Force -Verbose
Add-Migration Initial
Update-Database
```


