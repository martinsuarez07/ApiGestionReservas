Sistema de Gestión de Reservas

API REST desarrollada con C# y ASP.NET Core para la administración de usuarios, servicios, horarios y reservas.

El proyecto está orientado a la gestión de reservas en gimnasios y otros establecimientos que requieren administrar turnos y disponibilidad.

Tecnologías utilizadas

C# / .NET / ASP.NET Core

Entity Framework Core

SQL Server

LINQ

Postman

Git y GitHub

Arquitectura

El sistema utiliza una arquitectura en capas, aplicando principios SOLID, Programación Orientada a Objetos (POO) y el patrón Repository.

La solución está organizada en cinco proyectos:

ApiGestionReservas: Controladores y endpoints REST.

LogicaNegocio: Entidades, interfaces y reglas de negocio.

LogicaAplicacion: Casos de uso y lógica de aplicación.

LogicaAccesoDatos: Persistencia de datos y repositorios.

DTOs: Objetos de transferencia de datos.

Funcionalidades

Gestión y consulta de usuarios.

Registro y cancelación de reservas.

Consulta de horarios disponibles.

Validación de disponibilidad y cupos.

Control de reservas duplicadas.

Registro y consulta de asistencias.

Acceso a datos mediante Entity Framework Core.

Pruebas

Los endpoints de la API fueron probados utilizando Postman, verificando respuestas HTTP y validaciones de negocio.

Objetivo

Aplicar conocimientos de desarrollo Backend con .NET, arquitectura en capas, bases de datos relacionales y buenas prácticas de ingeniería de software.

Autor

Martín Suárez
Estudiante de Licenciatura en Sistemas – Universidad ORT Uruguay.
