# Creación de CRUD en ASP.NET EF 7.0 con SQL Server y MVC

Este repositorio contiene un ejemplo de cómo crear un sistema CRUD (Create, Read, Update, Delete) utilizando ASP.NET EF 7.0, SQL Server, y el patrón de arquitectura Modelo-Vista-Controlador (MVC). Este proyecto fue desarrollado como parte de mi formación académica en el Instituto Nacional de Aprendizaje (INA), y utiliza tecnologías como Bootstrap, jQuery y JavaScript para mejorar la interfaz de usuario y la interacción con el usuario.

## Requisitos previos

- Visual Studio (versión recomendada: 2019 o posterior)
- SQL Server (versión recomendada: 2017 o posterior)
- Conocimientos básicos de C#, ASP.NET y MVC

## Instalación

1. Clona este repositorio en tu máquina local usando el siguiente comando:

```bash
git clone https://github.com/TuUsuario/ProyectoCRUDASPNET.git
```

2. Abre el proyecto en Visual Studio.

3. Asegúrate de configurar la cadena de conexión a tu instancia de SQL Server en el archivo `appsettings.json`.

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=tu-servidor;Database=tu-base-de-datos;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

4. Abre la Consola del Administrador de Paquetes en Visual Studio y ejecuta las migraciones para crear la base de datos:

```bash
Update-Database
```

5. Compila y ejecuta la aplicación.

## Características

Este proyecto CRUD ofrece las siguientes funcionalidades:

- Creación, lectura, actualización y eliminación de registros en la base de datos.
- Interfaz de usuario amigable utilizando Bootstrap para una experiencia visual agradable.
- Integración de jQuery y JavaScript para mejorar la interacción del usuario.

## Estructura del proyecto

El proyecto está organizado siguiendo la estructura MVC estándar de ASP.NET:

- **Models**: Define las entidades de la base de datos y las configuraciones de Entity Framework.
- **Views**: Contiene las vistas HTML y las plantillas Razor para la interfaz de usuario.
- **Controllers**: Maneja la lógica de negocio y la interacción entre las vistas y los modelos.
- **Scripts**: Contiene archivos JavaScript y jQuery para mejorar la interacción del usuario.
- **wwwroot**: Contiene recursos estáticos como hojas de estilo, imágenes y archivos JavaScript.

## Contribuciones

Si encuentras errores, mejoras o nuevas características que podrían ser agregadas, ¡no dudes en contribuir! Abre un pull request y estaré encantado de revisarlo.

## Licencia

Este proyecto se distribuye bajo la Licencia MIT. Siéntete libre de usarlo y modificarlo según tus necesidades.

---

Espero que este README te ayude a comprender cómo crear un CRUD en ASP.NET EF 7.0 utilizando SQL Server y el patrón MVC, como parte de tu formación académica en el INA. Si tienes alguna pregunta o necesitas ayuda adicional, no dudes en contactarme. ¡Feliz codificación!
