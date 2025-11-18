# Gestor de Inscripciones (ASP.NET Core + JSON)

Proyecto de ejemplo para aprendices: captura datos desde un formulario y los guarda en un archivo JSON.

## Requisitos
- .NET SDK 8.0 (o 7.0 con pequeños ajustes)
- Visual Studio Code o Visual Studio / cualquier editor de texto
- Terminal (dotnet CLI)

## Estructura
- Controllers/: Controlador MVC que maneja rutas para crear/listar/editar/eliminar
- Models/: Modelo `Inscripcion`
- Services/: `InscripcionService` para leer/escribir el archivo JSON en `data/inscripciones.json`
- Views/: Vistas Razor para `Crear`, `Listar` y `Editar`
- wwwroot/: Archivos estáticos (CSS)
- data/inscripciones.json: archivo JSON donde se persisten las inscripciones

## Pasos para ejecutar (desde la carpeta del proyecto)
1. Abrir terminal en la carpeta del proyecto (donde está el `.csproj`).
2. Restaurar dependencias (opcional en la mayoría de casos):
   ```bash
   dotnet restore
   ```
3. Ejecutar la app:
   ```bash
   dotnet run
   ```
4. Abrir el navegador en `https://localhost:5001` o `http://localhost:5000` (la consola mostrará la URL exacta).

## Notas pedagógicas
- La lógica de persistencia está separada en `InscripcionService` (asegúrate de revisar locking y manejo de errores).
- Para producción **no** es recomendable usar archivos JSON planos como persistencia principal — usar una base de datos. Este ejercicio es para aprender IO y serialización.
- Actividades sugeridas para la clase: validar en el cliente, mejorar UI, paginar resultados, exportar a CSV, tests unitarios para el servicio de persistencia.
