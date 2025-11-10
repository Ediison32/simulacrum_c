
# Creacion de los modelos

## gitignore:
- dotnet new gitignore


## conexion db
- Base de datos desplegada en **aiven**
- 1 INSTALAR  :: dotnet add package microsoft.EntityFrameworkCore --version 8.0
- 2 INSTALAR  :: dotnet add package Microsoft.EntityFrameworkCore.Desig --version 8.0
-  3 INSTALAR  :: dotnet add package Pomelo.EntityFrameworkCore.Mysql --version 8.0
-  4  INSTALAR  :: dotnet tool install --global dotnet-ef
- Verificar que este importando Entity
- Configuraciones para la variable de entorno y traer la configuracion de la db
- para finalizar necesitamos ejeccutar los siguientes comando para crear la migracion y para crear la db en la base de datos }

## Migracion desde DDD ---> importante

                       *Estar en la RAIZ DEL PROYECTO PARA EJECUTAR*

    - dotnet ef migrations add InitialCreate --project apiweb.Infrastructure --startup-project apiweb.Api
    - dotnet ef database update --project apiweb.Infrastructure --startup-project apiweb.Api


                            *Que significa*

    - project              Indica dónde está tu AppDbContext y dónde se guardarán las migraciones.
    -startup-project       Indica desde dónde se ejecutará la configuración de EF (el Program.cs que tiene la conexión).


# 1 crear proyecto
# 2 modelos
# 3 conexion db y migracion
# 4  implementar
# 5 servicion
# 6 Dto

# 7 SEvices dentro de interfaces del aplication
# 8 api crear controller
# 9 inyectar en program

