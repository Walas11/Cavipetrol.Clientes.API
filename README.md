# Cavipetrol.Clientes.API
Prueba técnica - Desarrollador Fullstack Cavipetrol

Este documento resume dónde está cada entregable de la prueba técnica de bases de datos.

## 1. RUEBA TÉCNICA – BASE DE DATOS SQL SERVER

Archivo: **`RUEBA TÉCNICA – BASE DE DATOS SQL SERVER.txt`**

Contiene el desarrollo completo de la prueba técnica de SQL Server, independiente de la API de Clientes:

- Creación de la base de datos `EmpresaDB`.
- Tablas `Departamentos`, `Empleados`, `Proyectos` y la tabla intermedia `EmpleadoProyecto` (relación N:M), con llaves primarias y foráneas.
- Registros de prueba (mínimo 5 por tabla).
- Consultas solicitadas: empleados con su departamento, proyectos con presupuesto y cantidad de empleados asignados, top 3 empleados con más proyectos, departamentos sin empleados, empleados en más de un proyecto.
- Procedimiento almacenado `sp_buscar_empleado` (búsqueda de empleado por nombre, con datos del departamento).
- Función escalar `fn_total_proyectos` (total de proyectos asignados a un empleado).
- Índice no clúster sobre `Apellido` en la tabla `Empleados`.
- Explicación de backup y restore en SQL Server.

## Ubicación del script de base de datos

El script completo de la base de datos (creación de la base `DBClientes`, tabla `Clientes`, índice, datos de prueba y stored procedure) se encuentra en el archivo:

**`DBClientes.txt`**

Ese archivo incluye:
- Creación de la base de datos `DBClientes`.
- Creación de la tabla `Clientes` con sus llaves primarias y restricciones.
- Índice no clúster sobre la columna `Identificacion` para optimizar la búsqueda.
- Inserción de datos de prueba (5 registros).
- Stored procedure `sp_ObtenerCliente`, usado por el endpoint `GET /api/clientes/{identificacion}` de esta API.
- Consulta de ejemplo para probar el SP directamente en SQL Server Management Studio.

## Resumen de lo implementado en la API

Este proyecto (`Cavipetrol.Clientes.API`) cumple con los requisitos de la prueba técnica de desarrollador Fullstack:

- **Framework:** .NET 6 Web API.
- **Base de datos:** SQL Server 2019 / LocalDB, consumida mediante Entity Framework Core.
- **Arquitectura en capas:**
  - `API` – Controladores y configuración de la aplicación (`AuthController`, `ClientesController`, Swagger, JWT).
  - `Services` – Lógica de negocio (`AuthService`, `ClienteService`).
  - `Repositories` – Acceso a datos con EF Core, incluyendo el `DbContext` y la invocación del stored procedure.
  - `DTOs` – Objetos de transferencia de datos expuestos por la API.
- **Autenticación:** JWT mediante `POST /api/auth/login`, requerido para consumir el endpoint de clientes.
- **Documentación:** Swagger/OpenAPI, incluyendo definición del esquema de seguridad Bearer para probar el token desde la misma interfaz.
- **Endpoint principal:**

GET /api/clientes/{identificacion}

  Devuelve los datos del cliente si existe, o `404 Not Found` si no se encuentra la identificación.

## Cómo probar la API

1. Ejecutar el script `DBClientes.txt` en SQL Server para crear la base, la tabla y el SP.
2. Ajustar la cadena de conexión en `appsettings.json` si es necesario.
3. Levantar el proyecto desde Visual Studio 2022.
4. En Swagger, ejecutar `POST /api/auth/login` con las credenciales de prueba y copiar el token retornado.
5. Hacer clic en **Authorize** e ingresar `Bearer {token}`.
6. Ejecutar `GET /api/clientes/{identificacion}` con una identificación existente (por ejemplo, `1010101010`).
