# INTRUCIONES PARA LEVANTAR EL PROYECTO:
### Requisitos
- .NET8
- Docker

### Creando la base de datos con docker:
```sh
docker run --name mydb-sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```
### Conectarse al contenedor y crear la base de datos llamada `my_db`

```
docker exec -it mydb-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U 'sa' -P 'yourStrong(!)Password' -C
```
```
CREATE DATABASE my_db;
GO
```

### Ingresos de datos del script `data.sql`
> Se recomienda usar una UI para esto, por ejemplo:
- tableplus
- dbeaver