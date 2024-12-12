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

### Ingresos de datos del script [data.sql](https://github.com/xOnlinEx/prueba-tecnica/blob/main/prueba-tecnica/data.sql) (puede ver el ejemplo de abajo)
> Se recomienda usar una UI para esto, por ejemplo:
- [tableplus](https://tableplus.com/)
- [dbeaver](https://dbeaver.io/)

### Abrir tableplus
![Image text](https://github.com/xOnlinEx/prueba-tecnica/blob/main/.asserts/1.png)
### Elegir Sqlserver
![Image text](https://github.com/xOnlinEx/prueba-tecnica/blob/main/.asserts/2.png)
### ingresar los datos del contenedor
```
{
    'host': 'localhost',
    'port': '1433',
    'user': 'sa',
    'password': 'yourStrong(!)Password',
    'database': my_db
}
```
![Image text](https://github.com/xOnlinEx/prueba-tecnica/blob/main/.asserts/3.png)
### Ingreso de datos [data.sql](https://github.com/xOnlinEx/prueba-tecnica/blob/main/prueba-tecnica/data.sql)
![Image text](https://github.com/xOnlinEx/prueba-tecnica/blob/main/.asserts/4.png)
