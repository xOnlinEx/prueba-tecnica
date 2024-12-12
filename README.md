# INSTRUCIONES PARA LEVANTAR EL PROYECTO:
### Requisitos
- .NET8
- Docker

### Creando la base de datos con docker:
```sh
docker run --name mydb-sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```
### Conectarse al contenedor y crear la base de datos llamada `my_db`

```sh
docker exec -it mydb-sqlserver /opt/mssql-tools18/bin/sqlcmd -S localhost -U 'sa' -P 'yourStrong(!)Password' -C
```
---
> [! NOTE] puede que al pegar el siguiente comando, solo ingrese la primera fila, se recomienda hacerlo uno por uno. 
```sql
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
```js
{
    'host': 'localhost',
    'port': '1433',
    'user': 'sa',
    'password': 'yourStrong(!)Password',
    'database': 'my_db'
}
```
![Image text](https://github.com/xOnlinEx/prueba-tecnica/blob/main/.asserts/3.png)
### Ingreso de datos [data.sql](https://github.com/xOnlinEx/prueba-tecnica/blob/main/prueba-tecnica/data.sql)
![Image text](https://github.com/xOnlinEx/prueba-tecnica/blob/main/.asserts/4.png)

### Finalmente para correr el proyecto use el siguiente comando
> [! IMPORTANT] deberia esta en esta ruta para poder ingresar el comando
```sh
cd /Users/tu_usuario/ubicacion/del/proyecto/prueba-tecnica/prueba-tecnica
```
```sh
dotnet run
```

> [! NOTE] para hacer el consumo de los endpoints, por ahora no se recomienda usar swagger ya que no se implemento el ingreso para token (pero puedo revisar la pagina swagger para verificar las rutas de los endpoint, se recomiendo no ingresar datos fallidos ya que aun no se tiene la valicion del mismo, asi como correos repetidos, etc).